using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Crocat Café/Oven Script",0)]
public class OvenScript : ObjectScript
{
    [Header("OBJECTS REFERENCES")]
    public Text breads, pasta;
    [Header("OBJECT STATS")]
    [SerializeField] private int bakeTime = 3;


    public override void Start()
    {
        base.Start();
        armazen = GameObject.Find("Armazen");
    }
    public override void OpenUi()
    {
        Debug.Log("Open Oven Ui");
    }
    
    public void Bake()
    {
        if (armazen.GetComponent<Armazen>().massasAtual >= 1){
            StartCoroutine(BakeBread());
        }
    }
    private IEnumerator BakeBread()
    {
        yield return new WaitForSeconds(bakeTime);

        
        armazen.GetComponent<Armazen>().massasAtual =- 1;
        armazen.GetComponent<Armazen>().breads += 1;
    }
}
