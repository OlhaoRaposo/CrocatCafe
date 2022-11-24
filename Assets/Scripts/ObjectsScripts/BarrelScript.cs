using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Barrel Script", 0)]
public class BarrelScript : MonoBehaviour
{
    [Header("OBJECTS REFERENCES")]
    public UiLoaderScript uiLoader;
    public GameObject armazen, currentBarrel;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 30;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
        ReloadReferences();
    }
    public void OpenUi(GameObject barrel)
    {
        currentBarrel = barrel;
        uiLoader.OpenUi();
    }

    public void MakeQueijo()
    {
        if (armazen.GetComponent<Armazen>().leiteAtual > 0)
        {
            SetDestinationToBarrel();
            armazen.GetComponent<Armazen>().RemoveLeite(1);
            StartCoroutine(BakeQueijo());
        }
    }

    private void SetDestinationToBarrel()
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(currentBarrel, bakeTime);
    }
    public void ReloadReferences()
    {
        armazen.GetComponent<Armazen>().AtualizaTxt();
    }

    private IEnumerator BakeQueijo()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisBarrel = currentBarrel;
        while(Vector3.Distance(thisBarrel.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaQueijo(1);
        ReloadReferences();
    }
}
