using UnityEngine;

public class CameraController : MonoBehaviour{
    private bool allowMovement = true;
    public float panSpeed = 10f;
    public float panBorderT = 1f;
    void Update(){

        if (!allowMovement) return;


        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderT) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderT)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey("a") || Input.mousePosition.x >= Screen.width - panBorderT)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey("d") || Input.mousePosition.x <= panBorderT)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        }

    } 
}
