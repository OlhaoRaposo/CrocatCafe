using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour
{
    public Vector3 screenPosition, worlPosition;
    void Update()
    {
        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitData)) {
            worlPosition = hitData.point;
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gmbj = hitData.collider.gameObject;
            gmbj.GetComponent<ObjectScript>().OpenUi();
        }
    }
}
