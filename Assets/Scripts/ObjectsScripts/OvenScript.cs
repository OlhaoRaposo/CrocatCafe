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
        ReloadReferences();
    }

    public void Bake()
    {
        if (armazen.GetComponent<Armazen>().massasAtual >= 1)
        {
            GameObject cat = GameObject.Find("Cat");
            GameObject oven = GameObject.Find("Furnace(Clone)");
            cat.GetComponent<NavMeshScript>().BakeDestin(oven,bakeTime);
            armazen.GetComponent<Armazen>().RemoveMassas(1);
            StartCoroutine(BakeBread());
            ReloadReferences();
        }
    }

    public void ReloadReferences()
    {
        breads.text = "Breads: " + armazen.GetComponent<Armazen>().breads.ToString();
        pasta.text = "Massas: " + armazen.GetComponent<Armazen>().massasAtual.ToString();
    }


    private IEnumerator BakeBread()
    {
        yield return new WaitForSeconds(bakeTime);
        Debug.Log("Adicionou");
        armazen.GetComponent<Armazen>().AdicionaPao(1);
        ReloadReferences();
    }
}
