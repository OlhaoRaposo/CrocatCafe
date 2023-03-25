using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDayState : StateFSM
{
    private WheatherManagerFSM wheatherManager; 
    public RainDayState(
        WheatherManagerFSM wheatherManager){
        this.wheatherManager = wheatherManager;
    }
    private GameObject particle;
    
    public void Enter()
    {
        Debug.Log("Enter RainDay");
    }
    public void Update()
    {
        
    }
    public void Exit()
    {
    }
}
