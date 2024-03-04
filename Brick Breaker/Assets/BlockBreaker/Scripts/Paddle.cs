using UnityEngine;

public class Paddle : MonoBehaviour
{
    Vector2 screenBounds;
    float objectWidthHalf;

    [SerializeField] BallMovement ball;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;

        #region Explanation
        //converting the screen bounds to the same coordinate system as the paddle. screen bounds will return half the width
        //and height of the screen. if the width is 8, the value returned will be 4
        #endregion
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z)); 
        objectWidthHalf = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update()
    {
        PaddlePosition();
    }

    private void PaddlePosition()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(GetXPos(), screenBounds.x * -1 + objectWidthHalf, screenBounds.x - objectWidthHalf);
        transform.position = pos;
    }

    private float GetXPos()
    {
        float mouseX = cam.ScreenToWorldPoint(Input.mousePosition).x;

        if (DebugSettings.instance.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        else
            return mouseX;           
    }
}
