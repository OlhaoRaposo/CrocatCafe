using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Oven Script", 0)]
public class OvenScript : MonoBehaviour
{
    [Header("OBJECTS REFERENCES")]
    public Text breads;
    public Text pasta;
    public UiLoaderScript uiLoader;
    public GameObject armazen;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 25;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
        ReloadReferences();
    }
    public void OpenUi()
    {
        uiLoader.OpenUi();
    }
    public void MakeBread()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0) {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            StartCoroutine(BakeBread());
            ReloadReferences();
        }
    }
    public void MakeCoffe()
    {
        if (armazen.GetComponent<Armazen>().frutaCafeAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveFrutaCafe(1);
            StartCoroutine(BakeCoffe());
        }
    }
    public void MakeJuice()
    {
        if (armazen.GetComponent<Armazen>().laranjaAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveLaranjas(1);
            StartCoroutine(BakeJuice());
        }
    }
    public void MakeCoxinha()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0 && armazen.GetComponent<Armazen>().frangoAtual > 0 && armazen.GetComponent<Armazen>().queijoAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            armazen.GetComponent<Armazen>().RemoveFrango(1);
            armazen.GetComponent<Armazen>().RemoveQueijo(1);
            StartCoroutine(BakeCoxinha());
        }
    }
    public void MakeCake()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0 && armazen.GetComponent<Armazen>().acucarAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            armazen.GetComponent<Armazen>().RemoveAcucar(1);
            StartCoroutine(BakeCake());
        }
    }
    public void MakeCheeseBread()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0 && armazen.GetComponent<Armazen>().queijoAtual > 0)
        {
            SetDestinationToFurnace();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            armazen.GetComponent<Armazen>().RemoveQueijo(1);
            StartCoroutine(BakeCheeseBread());
        }
    }
    private void SetDestinationToFurnace()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject oven = GameObject.Find("Furnace(Clone)");
        cat.GetComponent<NavMeshScript>().BakeDestin(oven, bakeTime);
    }
    public void ReloadReferences()
    {
        armazen.GetComponent<Armazen>().AtualizaTxt();
    }

    private IEnumerator BakeCheeseBread()
    {
        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaPaoDeQueijo(1);
        ReloadReferences();
    }
    private IEnumerator BakeCake()
    {
        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaBolos(1);
        ReloadReferences();
    }
    private IEnumerator BakeCoxinha()
    {
        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaCoxinha(1);
        ReloadReferences();
    }
    private IEnumerator BakeJuice()
    {
        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaSucos(1);
        ReloadReferences();
    }
    private IEnumerator BakeCoffe()
    {
        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaCafé(1);
        ReloadReferences();
    }
    private IEnumerator BakeBread()
    {
        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaPao(1);
        ReloadReferences();
    }
}
