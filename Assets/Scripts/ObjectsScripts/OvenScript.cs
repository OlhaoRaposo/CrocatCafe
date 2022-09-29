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
    [SerializeField] private int bakeTime = 3;


    public void Start()
    {
        armazen = GameObject.Find("Armazen");
    }
    public void OpenUi()
    {
        ReloadReferences();
        uiLoader.OpenUi();
    }

    public void Bake()
    {
        if (armazen.GetComponent<Armazen>().massasAtual >= 1)
        {
            GameObject cat = GameObject.Find("Cat");
            GameObject oven = GameObject.Find("Furnace(Clone)");
            cat.GetComponent<NavMeshScript>().BakeDestin(oven);
            StartCoroutine(BakeBread());
        }
    }

    public void ReloadReferences()
    {
        breads.text = "Breads:" + armazen.GetComponent<Armazen>().breads.ToString();
        pasta.text = "Massas: " + armazen.GetComponent<Armazen>().massasAtual.ToString();
    }


    private IEnumerator BakeBread()
    {
        yield return new WaitForSeconds(bakeTime);


        armazen.GetComponent<Armazen>().massasAtual -= 1;
        armazen.GetComponent<Armazen>().breads += 1;
        ReloadReferences();
    }
}
