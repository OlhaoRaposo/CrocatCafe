using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Juicer Script", 0)]
public class JuicerScript : MonoBehaviour
{
    [Header("OBJECTS REFERENCES")]
    public UiLoaderScript uiLoader;
    public GameObject armazen, currentJuicer;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 25;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
        ReloadReferences();
    }
    public void OpenUi(GameObject Juicer)
    {
        currentJuicer = Juicer;
        uiLoader.OpenUi();
    }

    public void MakeJuice()
    {
        if (armazen.GetComponent<Armazen>().laranjaAtual > 0)
        {
            SetDestinationToJuicer();
            armazen.GetComponent<Armazen>().RemoveLaranjas(1);
            StartCoroutine(BakeJuice());
        }
    }

    private void SetDestinationToJuicer()
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(currentJuicer, bakeTime);
    }
    public void ReloadReferences()
    {
        armazen.GetComponent<Armazen>().AtualizaTxt();
    }

    private IEnumerator BakeJuice()
    {
        GameObject cat = GameObject.Find("Cat");
        GameObject thisJuicer = currentJuicer;
        while(Vector3.Distance(thisJuicer.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(bakeTime);
        armazen.GetComponent<Armazen>().AdicionaSucos(1);
        ReloadReferences();
    }
}
