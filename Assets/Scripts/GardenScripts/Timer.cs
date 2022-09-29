using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]private float timeAmmount, progress;
    [SerializeField]private bool isReady;
    private enum TimerType {regularTimer, plantTimer, cookTimer}
    [SerializeField]private TimerType timer = TimerType.regularTimer;
    private float stageChangeTreshHold = 0.33f;

    private void Awake()
    {
        Invoke("Grow", 0.0f);
    }

    private void Grow()
    {
        if(progress < 1.0f)
        {
            progress += 1 / timeAmmount;
            if(timer != TimerType.regularTimer)
            {
                if(timer == TimerType.plantTimer)
                {
                    if(progress >= stageChangeTreshHold)
                    {
                        Debug.Log("Cresceu");
                        stageChangeTreshHold += 0.33f;
                        Plant thisPlant = gameObject.GetComponent<Plant>();
                        thisPlant.Grow();
                    }
                }
            }
            Invoke("Grow", 1.0f);
        }
        else
        {
            isReady = true;
            return;
        }
    }

    
    
}
