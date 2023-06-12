using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    [Header("Reference")]
    public WheatherManagerFSM wheatherManager;

    public Image tomorowClime;
    public Image todayClime;
    public Image monthClime;
    
    
    
    [SerializeField]
    private string[] dayWheather;

    
    private float aux;
    void ShowWheather()
    {
        int i = 0;
        foreach (int trigger in wheatherManager.dayTrigger)
        {
            foreach (Events getEvent in wheatherManager.atualWheather.events)
            {
                if (Enumerable.Range(getEvent.minTrigger, getEvent.maxTrigger).Contains(trigger)) {
                    dayWheather[i] = getEvent.EventName;
                    if (i == 0) {
                       todayClime.sprite = getEvent.eventImage;
                    }else if (i == 1) { 
                        tomorowClime.sprite = getEvent.eventImage;
                    }
                }
            }
            i++;
        }
        monthClime.sprite = wheatherManager.atualWheather.monthImage;
    }
}
