using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDayState : StateFSM
{
    private WheatherManagerFSM wheatherManager; 
    public FlowerDayState(
        WheatherManagerFSM wheatherManager){
        this.wheatherManager = wheatherManager;
    }
    private GameObject particle;
    public void Enter()
    {
        Debug.Log("Enter FlowersDay");
    }
    public void Update()
    {
        
    }
    public void Exit()
    {
    }
}
