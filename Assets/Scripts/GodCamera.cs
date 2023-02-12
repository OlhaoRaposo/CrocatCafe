using UnityEngine;

public class GodCamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private float speed, rotation, brakeTime, zoomStrength;

    [Header("Limits")]
    [SerializeField] private float posLimit_X, maxPosLimit_Y, minPosLimit_Y, posLimit_Z;
    private Vector3 pos, lastMousePos = Vector3.zero, zoomCordinates, zoomAmmount;
    private Quaternion newRotation;

    private void Start()
    {
        pos = transform.position;
        newRotation = transform.rotation;
        zoomCordinates = cameraObject.transform.localPosition;
        zoomAmmount = new Vector3(0, -zoomStrength, zoomStrength * 8.5f/15);
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            pos += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos += -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos += -transform.right * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos += transform.right * speed;
        }

        if (Input.GetMouseButton(1) == true)
        {
            Vector3 mouseMovement = Input.mousePosition - lastMousePos;

            if (mouseMovement.x < 0) //Esquerda
            {
                newRotation *= Quaternion.Euler(Vector3.up * -rotation);
            }

            if (mouseMovement.x > 0) //Direita
            {
                newRotation *= Quaternion.Euler(Vector3.up * rotation);
            }

            lastMousePos = Input.mousePosition;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                zoomCordinates += zoomAmmount;
            }
            else
            {
                zoomCordinates -= zoomAmmount;
            }
        }

        if (transform.position.x > posLimit_X)
        {
            pos += new Vector3(-1, 0, 0);
        }
        if (transform.position.x < -posLimit_X)
        {
            pos += new Vector3(1, 0, 0);
        }
        if (transform.position.z > posLimit_Z)
        {
            pos += new Vector3(0, 0, -1);
        }
        if (transform.position.z < -posLimit_Z)
        {
            pos += new Vector3(0, 0, 1);
        }

        if (cameraObject.transform.localPosition.y > maxPosLimit_Y)
        {
            zoomCordinates += new Vector3(0, -1, 8.5f/15);
        }

        if (cameraObject.transform.localPosition.y < minPosLimit_Y)
        {
            zoomCordinates += new Vector3(0, 1, -8.5f/15);
        }

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * brakeTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * brakeTime);
        cameraObject.transform.localPosition = Vector3.Lerp(cameraObject.transform.localPosition, zoomCordinates, Time.deltaTime * brakeTime);
    }
}
