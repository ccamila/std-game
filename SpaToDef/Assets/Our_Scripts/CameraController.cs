using UnityEngine;

public class CameraController : MonoBehaviour{
    private bool allowMovement = false;
    public float panSpeed = 10f;
    public float panBorderT = 1f;
    public float scrollSpeed = 5f;
    private float minY = 1f;
    private float maxY = 10f;

    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;

    void Update()
    {
        if (GameMananger.gameEnded){
            this.enabled = false;
        }

        if (Input.GetMouseButton(0)) allowMovement = !allowMovement;
        if (!allowMovement) return;


        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderT)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderT)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderT)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderT)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        //Zoom:
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 currentPosition = transform.position;

        currentPosition.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        transform.position = currentPosition;

        move();
    }

    void move()
    {
        if (right)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        else if (left)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        else if (up)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        else if (down)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
    }

    public void down_right()
    {

        right = true;
    }

    public void up_right()
    {
        right = false;
    }

    public void up_left()
    {
        left = false;
    }

    public void down_left()
    {
        left = true;

    }

    public void up_up()
    {
        up = false;
    }

    public void down_up()
    {
        up = true;
    }

    public void up_down()
    {
        down = false;
    }

    public void down_down()
    {
        down = true;
    }
}
