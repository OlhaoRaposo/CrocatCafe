using UnityEngine;

public class AimMove : MonoBehaviour
{
    public Vector3 screenPosition, worlPosition;
    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            worlPosition = hitData.point;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (hitData.collider == null) {
                return;
            }
            else {
                GameObject gmbj = hitData.collider.gameObject;
                if (gmbj.GetComponent<ObjectScript>() != null) {
                    
                    gmbj.GetComponent<ObjectScript>().ObjectInteract();
                }
            }
        }
    }
}
