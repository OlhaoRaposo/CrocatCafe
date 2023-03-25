using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheatherManagerFSM : MonoBehaviour
{
    StateFSM state;
    [Header("MonthSystem")]
    [SerializeField] public MonthStats[] monthStats;
    [SerializeField] public months atualMonthState;
    public enum months
    {
        isRainMonth, isHotMonth, isFlowerMonth, isColdMonth
    }
    void Update()
    {
        state?.Update();
    } 
    public void SetState(StateFSM state)
     {
         state?.Exit();
         this.state = state;
         state?.Enter();
     }
    
    //Atualiza as estações de acordo com os meses
     public void MonthSelection(int monthType)
     {
         //Switch Case pra selecionar a estação
        
         switch (monthType) {
             case 0:
                atualMonthState = months.isFlowerMonth;
                 break;
             case 1:
                 atualMonthState = months.isHotMonth;
                 break;
             case 2:
                atualMonthState = months.isRainMonth;
                 break;
             case 3:
                 atualMonthState = months.isColdMonth;
                 break;
         }
         Debug.Log(monthType);
         GetSetWheather();
     }
     
     //Le a lista de meses pra pegar o mes atual
     public void GetSetWheather()
     {
         MonthStats atualWheather = new MonthStats();
        foreach (MonthStats monthType in monthStats)
        {
            if (atualMonthState == months.isColdMonth){
                if (monthType.monthName == "ColdMonth") {
                    atualWheather = monthType;
                }
            }
            else if (atualMonthState == months.isFlowerMonth) {
                if (monthType.monthName == "FlowerMonth") {
                    atualWheather = monthType;
                }
            }
            else if (atualMonthState == months.isHotMonth) {
                if (monthType.monthName == "HotMonth") {
                    atualWheather = monthType;
                }
            }else if (atualMonthState == months.isRainMonth) {
                if (monthType.monthName == "RainMonth") {
                    atualWheather = monthType;
                }
            }
        }
        SetWheather(atualWheather);
        Debug.Log("Atual: " + atualWheather.monthName);
     }
     
    //Escolhe a probabilidade do dia dependendo do mes
     private void SetWheather(MonthStats atualWheather)
     {
         int dayWheather;
         dayWheather = Random.Range(0, 101);
         //PrincipalEvent
         if (Enumerable.Range(atualWheather.principalEvent.minTrigger,atualWheather.principalEvent.maxTrigger).Contains(dayWheather))
         {
             TurnOnEvent(atualWheather.principalEvent.EventName);
         }else {
             //SideEvents
             foreach (Events getEvent in atualWheather.events)
             {
                 if (Enumerable.Range(getEvent.minTrigger, getEvent.maxTrigger).Contains(dayWheather))
                 {
                     TurnOnEvent(getEvent.EventName);
                 }
             }
         }
         
     }
     
     //Seta o stateMachine pro dia certo
     private void TurnOnEvent(string eventDay)
     {
         switch (eventDay)
         {
             case "RainEvent":
                 SetState(new RainDayState(this));
                 break;
             case "WindEvent":
                 SetState(new HotDayState(this));
                 break;
             case "FlowerEvent":
                 SetState(new FlowerDayState(this));
                 break;
             case "ColdEvent":
                 SetState(new ColdDayState(this));
                 break;
         }
     }
}
//Classes Dos Meses
[Serializable]
public class MonthStats
{
    [Header("Name")]
    public string monthName;

    [Header("PrincipalEvent")] 
    public Events principalEvent;
    [Header("SideEvents")] 
    public Events[] events;
}
[Serializable]
public class Events
{
    [Header("Name")]
    public string EventName;
    [Header("EventsTrigger")]
    [Range(0,100)]
    public int minTrigger;
    [Range(0,100)]
    public int maxTrigger;
    [Header("Particle")]
    public ParticleSystem dayParticles;
}
