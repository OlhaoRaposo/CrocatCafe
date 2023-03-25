using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDayState : StateFSM
{
    private WheatherManagerFSM wheatherManager; 
    public HotDayState(
        WheatherManagerFSM wheatherManager){
        this.wheatherManager = wheatherManager;
    }
    public void Enter()
    {
        Debug.Log("Enter HotDay");
    }
    public void Update()
    {
        
    }
    public void Exit()
    {
    }
}
