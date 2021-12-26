using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatClock
{

    private Action action;
    private Action action2;
    private float timer;
    private bool isDestroyed;
    private bool isSecondBeat;
    private int boomTumCounter;

    public BeatClock(Action action, Action action2, float timer)
    {
        this.action = action;
        this.action2 = action2;
        this.timer = timer;
        isSecondBeat = false;
        boomTumCounter = 1;
    }

    // Update is called once per frame
    public void Update() 
    {
        timer = 30 / timer;

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if(boomTumCounter == 1)
            {
                //Trigger the action
                action();
                timer = 95f;
                boomTumCounter = 0;
            }
            else
            {
                //Trigger alternate action
                action2();
                timer = 95f;
                boomTumCounter = 1;
            }
            
        }
        
    }

    //private void DestroySelf()
    //{
        //isDestroyed = true;
    //}
}
