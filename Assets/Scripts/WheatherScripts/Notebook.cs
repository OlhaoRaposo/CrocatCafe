using System;
using UnityEngine;
using System.Linq;

public class Notebook : MonoBehaviour
{
    [Header("Reference")]
    public WheatherManagerFSM wheatherManager;
    
    [SerializeField]
    private string[] dayWheather;

    void ShowWheather()
    {
        int i = 0;
        foreach (int trigger in wheatherManager.dayTrigger)
        {
            foreach (Events getEvent in wheatherManager.atualWheather.events)
            {
                if (Enumerable.Range(getEvent.minTrigger, getEvent.maxTrigger).Contains(trigger))
                {
                    dayWheather[i] = getEvent.EventName;
                }
                
            }
            i++;
        }
    }
}
