using UnityEngine;

public class PotScript : MonoBehaviour
{
    public GameObject armazen, seed, mySeed;
    public bool isOccupied;
    private Timer seedTimer;
    private void Start()
    {
        armazen = GameObject.Find("ArmazenManager");        
    }

    public void PlantSeed()
    {
        if(!isOccupied)
        {
            isOccupied = true;
            mySeed = Instantiate(seed, transform.position + new Vector3(0, 0.25f, 0), transform.rotation);
            seedTimer = mySeed.gameObject.GetComponent<Timer>();
            mySeed.transform.SetParent(gameObject.transform);
        }

        if(seedTimer.isReady == true)
        {
            armazen.GetComponent<Armazen>().AdicionaMassas(3);
            Destroy(mySeed);
            isOccupied = false;
        }
    }
}
