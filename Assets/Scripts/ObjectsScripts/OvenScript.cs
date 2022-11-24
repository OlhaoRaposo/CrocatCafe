using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Oven Script", 0)]
public class OvenScript : MonoBehaviour
{
    [Header("OBJECTS REFERENCES")]
    public UiLoaderScript uiLoader;
    public GameObject armazen, currentOven;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 15;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
        ReloadReferences();
    }
    public void OpenUi(GameObject oven)
    {
        currentOven = oven;
        uiLoader.OpenUi();
    }

    public void MakeCoffe()
    {
        if (armazen.GetComponent<Armazen>().frutaCafeAtual > 0)
        {
            SetDestinationToOven();
            armazen.GetComponent<Armazen>().RemoveFrutaCafe(1);
            StartCoroutine(BakeCoffe());
        }
    }

    private void SetDestinationToOven()
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(currentOven, bakeTime);
    }
    public void ReloadReferences()
    {
        armazen.GetComponent<Armazen>().AtualizaTxt();
    }

    private IEnumerator BakeCoffe()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisOven = currentOven;
        while(Vector3.Distance(thisOven.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaCafé(1);
        ReloadReferences();
    }
}
