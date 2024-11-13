using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Component
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region State
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerBlueState blueState { get; private set; }
    public PlayerYellowState yellowState { get; private set; }
    public PlayerRedState redState { get; private set; }
    public PlayerOrangeState orangeState { get; private set; }
    public PlayerPurpleState purpleState { get; private set; }
    public PlayerGreenState greenState { get; private set; }
    #endregion
    #region
    [HideInInspector] public bool canChangeState = false;
    [HideInInspector] public bool blueTrigger = false;
    [HideInInspector] public bool yellowTrigger = false;
    [HideInInspector] public bool redTrigger = false;
    [HideInInspector] public bool orangeTrigger = false;
    [HideInInspector] public bool purpleTrigger = false;
    [HideInInspector] public bool greenTrigger = false;
    #endregion
    [Header("Move Info")]
    public int moveDir = 1;
    public float moveSpeed;
    public float jumpForce;
    public float dashForce;
    [Header("Check Info")]
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundLayer;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        blueState = new PlayerBlueState(this, stateMachine, "Idle");
        yellowState = new PlayerYellowState(this, stateMachine, "Idle");
        redState = new PlayerRedState(this, stateMachine, "Idle");
        orangeState = new PlayerOrangeState(this, stateMachine, "Idle");
        purpleState = new PlayerPurpleState(this, stateMachine, "Idle");
        greenState = new PlayerGreenState(this, stateMachine, "Idle");

        //add more state

    }
    private void Start()
    {
        stateMachine.Initialize(idleState);
    }
    private void Update()
    {
        stateMachine.currentState.Update();
    }
    public void Movement()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime * moveDir, 0, 0);
    }
    public void AdjustScale(float targetSize, bool isGrowing)
    {
        float deltaScale = moveSpeed * Time.deltaTime;

        float newX = isGrowing ?
            Mathf.Min(targetSize, transform.localScale.x + deltaScale) :
            Mathf.Max(targetSize, transform.localScale.x - deltaScale);

        float newY = isGrowing ?
            Mathf.Min(targetSize, transform.localScale.y + deltaScale) :
            Mathf.Max(targetSize, transform.localScale.y - deltaScale);

        transform.localScale = new Vector3(newX, newY, transform.localScale.z);
    }
    public void SetFacingDefault()
    {
        if (transform.localEulerAngles.y >= 360 || transform.localEulerAngles.z >= 360)
            transform.localEulerAngles = Vector3.zero;

    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public bool IsGrounded()
    {
      if(rb.gravityScale < 0)
            return Physics2D.Raycast(groundCheckPosition.position, Vector2.up, groundCheckDistance * transform.localScale.x, groundLayer);
        return Physics2D.Raycast(groundCheckPosition.position, Vector2.down, groundCheckDistance * transform.localScale.x, groundLayer);
    } 
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPosition.position, groundCheckPosition.position + Vector3.down * groundCheckDistance * transform.localScale.x);
        Gizmos.DrawLine(groundCheckPosition.position, groundCheckPosition.position + Vector3.up * groundCheckDistance * transform.localScale.x);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canChangeState)
        {
            if (collision.gameObject.tag == "Finish")
                GameManager.instance.ChangeState(GameManager.GameState.GameOver);
            if (collision.gameObject.tag == "End")
            {
                SceneLoadeManager.instance.LoadSceneByName("MainMenu");
                GameManager.instance.ChangeState(GameManager.GameState.MainMenu);
            }

            if (collision.gameObject.tag == "BlueFrame")
                blueTrigger = true;

            if (collision.gameObject.tag == "YellowFrame")
                yellowTrigger = true;

            if (collision.gameObject.tag == "RedFrame")
                redTrigger = true;

            if (collision.gameObject.tag == "OrangeFrame")
                orangeTrigger = true;

            if (collision.gameObject.tag == "PurpleFrame")
                purpleTrigger = true;

            if (collision.gameObject.tag == "GreenFrame")
                greenTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OrangeFrame")
            orangeTrigger = false;

        if (collision.gameObject.tag == "PurpleFrame")
            purpleTrigger = false;

        if (collision.gameObject.tag == "GreenFrame")
            greenTrigger = false;
    }
}
