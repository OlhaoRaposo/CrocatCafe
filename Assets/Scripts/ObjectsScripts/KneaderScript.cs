using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Kneader Script", 0)]
public class KneaderScript : MonoBehaviour
{
    [Header("OBJECTS REFERENCES")]
    public UiLoaderScript uiLoader;
    public GameObject armazen, currentKneader;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 25;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
        ReloadReferences();
    }
    public void OpenUi(GameObject Kneader)
    {
        currentKneader = Kneader;
        uiLoader.OpenUi();
    }
    public void MakeCheeseBall()
    {
        if (armazen.GetComponent<Armazen>().queijoAtual > 0 && armazen.GetComponent<Armazen>().massasAtual > 0)
        {
            SetDestinationToKneader();
            armazen.GetComponent<Armazen>().RemoveQueijo(1);
            armazen.GetComponent<Armazen>().RemoveMassas(1);

            StartCoroutine(BakeBolaQueijo());
        }
    }

    public void MakeCakeMass()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0 && armazen.GetComponent<Armazen>().acucarAtual > 0)
        {
            SetDestinationToKneader();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            armazen.GetComponent<Armazen>().RemoveAcucar(1);
            StartCoroutine(BakeMassaBolo());
            ReloadReferences();
        }
    }

    public void MakeCoxinhaMass()
    {
        if (armazen.GetComponent<Armazen>().massasAtual > 0 && armazen.GetComponent<Armazen>().frangoAtual > 0 && armazen.GetComponent<Armazen>().leiteAtual > 0)
        {
            SetDestinationToKneader();
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            armazen.GetComponent<Armazen>().RemoveFrango(1);
            armazen.GetComponent<Armazen>().RemoveLeite(1);
            StartCoroutine(BakeMassaCoxinha());
            ReloadReferences();
        }
    }
    private void SetDestinationToKneader()
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(currentKneader, bakeTime);
    }
    public void ReloadReferences()
    {
        armazen.GetComponent<Armazen>().AtualizaTxt();
    }

    private IEnumerator BakeBolaQueijo()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisKneader = currentKneader;
        while (Vector3.Distance(thisKneader.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaBolaQueijo(1);
        ReloadReferences();
    }

    private IEnumerator BakeMassaBolo()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisKneader = currentKneader;
        while (Vector3.Distance(thisKneader.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaMassaBolo(1);
        ReloadReferences();
    }

    private IEnumerator BakeMassaCoxinha()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisKneader = currentKneader;
        while (Vector3.Distance(thisKneader.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaMassaCoxinha(1);
        ReloadReferences();
    }
}
