using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour
{
    public GameObject seed, mySeed, myTimer;
    public bool isOccupied;
    public Plant myPlant;
    private GameObject armazen;
    private void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
    }

    public void InteractWithSeed()
    {
        StartCoroutine(WaitForCat());
    }

    private IEnumerator WaitForCat()
    {
        GameObject cat = GameObject.Find("Cat");
        if (!isOccupied) //Plantar
        {
            isOccupied = true;
            GardenScript.instance.SetDestinationToPot(gameObject, 5);
            cat.GetComponent<AnimationPlayer>().AddAnimation("MiaArmature|Walking", true);
            //cat.GetComponent<AnimationPlayer>().SkipAnimation();
            while (Vector3.Distance(gameObject.transform.position, cat.transform.position) >= 1)
            {
                yield return new WaitForSeconds(1);
            }
            cat.GetComponent<AnimationPlayer>().AddAnimation("MiaArmature|Planting", true);
            cat.GetComponent<AnimationPlayer>().SkipAnimation();

            mySeed = Instantiate(seed, transform.position + new Vector3(0, 0.25f, 0), transform.rotation);
            mySeed.transform.SetParent(gameObject.transform);

            myPlant = mySeed.GetComponent<Plant>();
            
            GameObject summonedTimer = Instantiate(myTimer, transform.position + Vector3.up, Quaternion.identity, gameObject.transform);
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

                    while (Vector3.Distance(gameObject.transform.position, cat.transform.position) >= 1)
                    {
                        yield return new WaitForSeconds(1);
                    }
                    cat.GetComponent<AnimationPlayer>().AddAnimation("MiaArmature|Planting", true);
                    cat.GetComponent<AnimationPlayer>().SkipAnimation();
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
