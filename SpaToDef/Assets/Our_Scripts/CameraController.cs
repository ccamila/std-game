using UnityEngine;

public class CameraController : MonoBehaviour{
    private bool allowMovement = true;
    public float panSpeed = 10f;
    public float panBorderT = 1f;
    public float scrollSpeed = 5f;
    private float minY = 10f;
    private float maxY = 80f;
    void Update()
    {
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

    } 


}
