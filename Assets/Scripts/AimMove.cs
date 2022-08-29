using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour
{
    public GameObject aim,player;
    public Vector3 screenPosition, worlPosition;
    public float smooth;
    public LayerMask layerToHit;
    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitData)) {
            worlPosition = hitData.point;
        }
        if (Input.GetMouseButton(0)) {
            aim.transform.position = worlPosition;
            player.transform.position = Vector3.Lerp(player.transform.position, aim.transform.position, smooth );
        }
    }
}
