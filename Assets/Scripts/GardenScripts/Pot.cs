using UnityEngine;

public class Pot : MonoBehaviour
{
    public GameObject seed, mySeed;
    public bool isOccupied;
    private GameObject armazen;
    private Plant myPlant;
    private void Start()
    {
        armazen = GameObject.Find("ArmazenManager");
    }

    public void InteractWithSeed()
    {
        if (!isOccupied) //Plantar
        {
            isOccupied = true;

            mySeed = Instantiate(seed, transform.position + new Vector3(0, 0.25f, 0), transform.rotation);
            mySeed.transform.SetParent(gameObject.transform);

            myPlant = mySeed.GetComponent<Plant>();
        }
        else
        {
            if (myPlant.isReady == true) //Coletar
            {
                isOccupied = false;
                
                //Lógica de adicionar loot ao inventário
                Destroy(mySeed);
                mySeed = null;
            }
        }
    }
}
