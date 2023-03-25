using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdDayState : StateFSM
{
    private WheatherManagerFSM wheatherManager; 
    public ColdDayState(
        WheatherManagerFSM wheatherManager){
        this.wheatherManager = wheatherManager;
    }
    private GameObject particle;
    public void Enter()
    {
        Debug.Log("Enter ColdDay");
    }
    public void Update()
    {
        
    }
    public void Exit()
    {
    }
}
