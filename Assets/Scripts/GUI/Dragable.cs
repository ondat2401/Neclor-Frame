using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    public bool dragging = true;
    public bool canDrag = true;
    private void Update()
    {
        if (dragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0;
            transform.position = newPosition;
        }
        if (!dragging && transform.position.x <= -14f
            && transform.position.y <= 2.5f && transform.position.y >= -2.5f
            ) {
            Destroy(gameObject);
            GameManager.instance.currentFrameCount++;
        }
    }
    private void OnMouseDrag()
    {
        if(GameManager.instance.currentState != GameManager.GameState.Playing && canDrag)
            dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
}
