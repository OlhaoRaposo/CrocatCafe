using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheatherManagerFSM : MonoBehaviour
{
    public Notebook note;
    StateFSM state;
    [Header("MonthSystem")]
    [SerializeField] public MonthStats[] monthStats;
    [SerializeField] public months atualMonthState;

    [Header("DaypercentTrigger")] 
    [SerializeField]
    public Events atualEvent;
    public int[] dayTrigger;
    [SerializeField]
    public MonthStats atualWheather;
    public enum months
    {
        isRainMonth, isHotMonth, isFlowerMonth, isColdMonth
    }

    private void Start()
    {
        DayTriggerRnd();
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
         GetSetWheather();
     }
     
     //Le a lista de meses pra pegar o mes atual
     public void GetSetWheather()
     { 
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
        SetWheather();
     }
     
    //Escolhe a probabilidade do dia dependendo do mes
     private void SetWheather()
     {
         DayTriggerRnd();
         int eventPercent = 0;
         eventPercent = dayTrigger[0];
         //PrincipalEvent
         foreach (Events getEvent in atualWheather.events)
         {
             if (Enumerable.Range(getEvent.minTrigger, getEvent.maxTrigger).Contains(eventPercent))
             {
                     atualEvent = getEvent;
                     Debug.Log(atualEvent.EventName);
                     TurnOnEvent(getEvent.EventName);
             }
         }
     }
     private void DayTriggerRnd()
     {
         int newDaytrigger;
         for (int j = 0; j < dayTrigger.Length; j++)
         {
             if (dayTrigger[j] > 100)
             {
                 dayTrigger[j] = Random.Range(0, 101);
             }
         }
         newDaytrigger = Random.Range(0, 101);
         dayTrigger[0] = dayTrigger[1];
         dayTrigger[1] = newDaytrigger;
         note.SendMessage("ShowWheather");
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

    [Header("Events")] 
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
    public GameObject dayParticles;
}
