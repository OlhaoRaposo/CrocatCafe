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
    
    public Image siteClime;
    public Image uiClime;
    
    [SerializeField]
    private string[] dayWheather;

    
    private float aux;
    private void Update()
    {
        
        
    }

    void SitePingPong()
    {
        aux = Mathf.PingPong(0, 1);
        if (aux == 0) {
            siteClime = todayClime;
        }else if (aux == 1) {
            siteClime = tomorowClime;
        }
    }

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
                       uiClime = getEvent.eventImage;
                    }else if (i == 1) { 
                        siteClime = getEvent.eventImage;
                    }
                }
            }
            i++;
        }
        
    }
}
