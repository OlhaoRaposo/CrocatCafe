using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour
{
    public GameObject seed, mySeed, myTimer;
    public bool isOccupied;
    public Plant myPlant;
    private GameObject armazen;
    public void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
    }

    public void InteractWithSeed()
    {
        StartCoroutine(WaitForCat());
    }

    private IEnumerator WaitForCat()
    {
        if (!isOccupied) //Plantar
        {
            isOccupied = true;
            GardenScript.instance.SetDestinationToPot(gameObject, 5);

            while (Vector3.Distance(gameObject.transform.position, GameObject.Find("Cat").transform.position) >= 1)
            {
                yield return new WaitForSeconds(1);
            }

            mySeed = Instantiate(seed, transform.position + new Vector3(0, 0.25f, 0), transform.rotation);
            mySeed.transform.SetParent(gameObject.transform);

            myPlant = mySeed.GetComponent<Plant>();
            
            GameObject summonedTimer = Instantiate(GameObject.Find("SaveFactory").GetComponent<SaveFactory>().progressBar, transform.position + Vector3.up, Quaternion.identity, gameObject.transform);
            summonedTimer.GetComponent<ProgressBar>().StartLoading(myPlant.data.growthTime);
        }
        else
        {
            if (myPlant != null)
            {
                if (myPlant.isReady == true) //Coletar
                {
                    GardenScript.instance.SetDestinationToPot(gameObject, 0);
                    myPlant.isReady = false;

                    while (Vector3.Distance(gameObject.transform.position, GameObject.Find("Cat").transform.position) >= 1)
                    {
                        yield return new WaitForSeconds(1);
                    }
                    isOccupied = false;
                    ArmazenManager.instance.AddIngredient(myPlant.data.loot.ingredientName, myPlant.data.lootAmmount);
                    Destroy(mySeed);
                    mySeed = null;

                    string audio = $"Collect_0{Random.Range(0, 6)}";
                    AudioBoard.instance.PlayAudio(audio);
                }
            }
        }
    }
}
