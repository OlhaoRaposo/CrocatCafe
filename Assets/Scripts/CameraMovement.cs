using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int borderThickness; //Largura em pixels da area onde o mouse move a camera
    [SerializeField] private Vector2 posLimit; //A posicao limite at� onde a camera pode se mover
    [SerializeField] private float maxPosLimit_Y, minPosLimit_Y;
    [SerializeField] private float scrollSpeed;

    enum IsAtYLimits { ISNOTATLIMIT_Y, ISMAX_Y, ISMINIMUM_Y } //Enum que diz se a camera esta com o zoom minimo ou maximo
    IsAtYLimits isAtYLimits;
    private void Update()
    {
        Vector3 pos = transform.position;
        isAtYLimits = CheckCameraPos();

        if (Input.mousePosition.y >= Screen.height - borderThickness)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= borderThickness)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - borderThickness)
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= borderThickness)
        {
            pos.x -= speed * Time.deltaTime;
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        switch (isAtYLimits)
        {
            case (IsAtYLimits.ISNOTATLIMIT_Y): pos += Camera.main.transform.forward * scroll * scrollSpeed * 50 * Time.deltaTime; break;
            case (IsAtYLimits.ISMINIMUM_Y): if (scroll < 0) pos += Camera.main.transform.forward * scroll * scrollSpeed * 50 * Time.deltaTime; break;
            case (IsAtYLimits.ISMAX_Y): if (scroll > 0) pos += Camera.main.transform.forward * scroll * scrollSpeed * 50 * Time.deltaTime; break;
        }

        pos.x = Mathf.Clamp(pos.x, -posLimit.x, posLimit.x);
        pos.y = Mathf.Clamp(pos.y, minPosLimit_Y, maxPosLimit_Y);
        pos.z = Mathf.Clamp(pos.z, -posLimit.y, posLimit.y);

        transform.position = pos;
    }
    IsAtYLimits CheckCameraPos()
    {
        if (transform.position.y <= 5.1f)
        {
            return IsAtYLimits.ISMINIMUM_Y;
        }
        if (transform.position.y >= 19.9f)
        {
            return IsAtYLimits.ISMAX_Y;
        }
        return IsAtYLimits.ISNOTATLIMIT_Y;
    }
}
