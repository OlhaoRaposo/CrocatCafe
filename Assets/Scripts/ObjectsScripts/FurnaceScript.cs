using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Furnace Script", 0)]
public class FurnaceScript : MonoBehaviour
{
    [Header("OBJECTS REFERENCES")]
    public UiLoaderScript uiLoader;
    public GameObject armazen, currentFurnace;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 25;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
        ReloadReferences();
    }
    public void OpenUi(GameObject furnace)
    {
        currentFurnace = furnace;
        uiLoader.OpenUi();
    }
    public void MakeBread()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            StartCoroutine(BakeBread());
            ReloadReferences();
        }
    }
    public void MakeCoxinha()
    {
        if (armazen.GetComponent<Armazen>().massaCoxinhaAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassaCoxinha(1);
            StartCoroutine(BakeCoxinha());
        }
    }
    public void MakeCake()
    {
        if (armazen.GetComponent<Armazen>().massaBoloAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassaBolo(1);
            StartCoroutine(BakeCake());
        }
    }
    public void MakeCheeseBread()
    {
        if (armazen.GetComponent<Armazen>().bolaQueijoAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveBolaQueijo(1);
            StartCoroutine(BakeCheeseBread());
        }
    }
    private void SetDestinationToFurnace()
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(currentFurnace, bakeTime);
    }
    public void ReloadReferences()
    {
        armazen.GetComponent<Armazen>().AtualizaTxt();
    }

    private IEnumerator BakeCheeseBread()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisFurnace = currentFurnace;
        while (Vector3.Distance(thisFurnace.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaPaoDeQueijo(1);
        ReloadReferences();
    }
    private IEnumerator BakeCake()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisFurnace = currentFurnace;
        while (Vector3.Distance(thisFurnace.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaBolos(1);
        ReloadReferences();
    }
    private IEnumerator BakeCoxinha()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisFurnace = currentFurnace;
        while (Vector3.Distance(thisFurnace.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaCoxinha(1);
        ReloadReferences();
    }
    private IEnumerator BakeBread()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisFurnace = currentFurnace;
        while (Vector3.Distance(thisFurnace.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaPao(1);
        ReloadReferences();
    }
}
