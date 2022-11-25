using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour
{
    public GameObject seed, mySeed;
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

                    switch (myPlant.plantCode)
                    {
                        case (1):
                            {
                                Armazen.instance.AdicionaMassas(3);
                                break;
                            }
                        case (2):
                            {
                                Armazen.instance.AdicionaFrutaCafe(3);
                                break;
                            }
                        case (3):
                            {
                                Armazen.instance.AdicionaLaranjas(3);
                                break;
                            }
                        case (4):
                            {
                                Armazen.instance.AdicionaFrango(3);
                                break;
                            }
                        case (5):
                            {
                                Armazen.instance.AdicionaAcucar(3);
                                break;
                            }
                        case (6):
                            {
                                Armazen.instance.AdicionaLeite(3);
                                break;
                            }
                    }
                    Destroy(mySeed);
                    mySeed = null;

                    string audio = $"Collect_0{Random.Range(0, 6)}";
                    AudioBoard.instance.PlayAudio(audio);

                    if (TutorialController.instance.tutorialProgress < 5)
                    {
                        TutorialController.instance.AdvanceTutorial();
                        TutorialController.instance.OpenTutorialWindow();
                    }
                }
            }
        }
    }
}
