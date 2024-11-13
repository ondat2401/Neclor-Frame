using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanel : MonoBehaviour
{
    private Animator anim;
    private bool isOpened = false;

    [SerializeField] List<GameObject> colorFramePrefabs = new List<GameObject>();
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnBtnClick()
    {
        if(GameManager.instance.currentState != GameManager.GameState.Playing)
        {
            if (!isOpened)
            {
                anim.SetTrigger("Open");
                isOpened = !isOpened;
            }
            else
            {
                anim.SetTrigger("Close");
                isOpened = !isOpened;
            }
        }
    }
    private void Update()
    {
        if (GameManager.instance.currentState == GameManager.GameState.Playing && isOpened)
        {
            isOpened = false;
            anim.SetTrigger("Close");
        }    

    }
    public void OnDragColor(GameObject _color)
    {
        bool isSpawned = false;

        foreach (GameObject _c in colorFramePrefabs)
        {
            if(_c.tag == _color.tag && !isSpawned)
            {
                if(GameManager.instance.currentFrameCount > 0)
                {
                    isSpawned = true;
                    SpawnNewFrame(_c);
                    GameManager.instance.currentFrameCount--;
                }
            }
        }
    }
    public void OnEndDragColor(GameObject _color)
    {
        FindObjectOfType<Draggable>().dragging = false;
    }
    private void SpawnNewFrame(GameObject _frame)
    {
        GameObject newFrame = Instantiate(_frame);

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newFrame.transform.position = newPosition;

        newFrame.AddComponent<Draggable>();
    }
}
