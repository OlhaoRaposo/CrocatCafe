using System.Collections;
using UnityEngine;

public class TrailerScript : MonoBehaviour
{
    public GameObject doorCamera, gardenCamera, roadCamera,staticRoad,miaCamera,defaultCamera;
    public GameObject mia;

    public GameObject[] events;
    [SerializeField]
    private Canvas canvas;
    public int aux = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (Input.GetKey(KeyCode.T)) {
                staticRoad.gameObject.SetActive(false);
                doorCamera.gameObject.SetActive(true);
                gardenCamera.gameObject.SetActive(false);
                roadCamera.gameObject.SetActive(false);
                miaCamera.gameObject.SetActive(false);
                defaultCamera.gameObject.SetActive(false);
            }
            if (Input.GetKey(KeyCode.Y)) {
                staticRoad.gameObject.SetActive(false);
                doorCamera.gameObject.SetActive(false);
                gardenCamera.gameObject.SetActive(true);
                roadCamera.gameObject.SetActive(false);
                miaCamera.gameObject.SetActive(false);
                defaultCamera.gameObject.SetActive(false);
            }
            if (Input.GetKey(KeyCode.U)) {
                staticRoad.gameObject.SetActive(false);
                doorCamera.gameObject.SetActive(false);
                gardenCamera.gameObject.SetActive(false);
                roadCamera.gameObject.SetActive(true);
                miaCamera.gameObject.SetActive(false);
                defaultCamera.gameObject.SetActive(false);
            }
            if (Input.GetKey(KeyCode.I)) {
                staticRoad.gameObject.SetActive(true);
                doorCamera.gameObject.SetActive(false);
                gardenCamera.gameObject.SetActive(false);
                roadCamera.gameObject.SetActive(false);
                miaCamera.gameObject.SetActive(false);
                defaultCamera.gameObject.SetActive(false);
                StartCoroutine(ChangeStation());

            }
            if (Input.GetKey(KeyCode.O)) {
                staticRoad.gameObject.SetActive(false);
                doorCamera.gameObject.SetActive(false);
                gardenCamera.gameObject.SetActive(false);
                roadCamera.gameObject.SetActive(false);
                miaCamera.gameObject.SetActive(true);
                defaultCamera.gameObject.SetActive(false);
                
            }
            if (Input.GetKey(KeyCode.P)) {
                staticRoad.gameObject.SetActive(false);
                doorCamera.gameObject.SetActive(false);
                gardenCamera.gameObject.SetActive(false);
                roadCamera.gameObject.SetActive(false);
                miaCamera.gameObject.SetActive(false);
                defaultCamera.gameObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                canvas.enabled = !canvas.isActiveAndEnabled;
            }
        }
    }

    IEnumerator ChangeStation()
    {
        
        foreach (GameObject obj in events)
        {
            obj.SetActive(false);
        }
        
        events[aux].SetActive(true);
        if (aux < events.Length)
            aux++;
        else if(aux == events.Length)
            aux = 0;
        yield return new WaitForSeconds(6);
        StartCoroutine(ChangeStation());
    }
}
