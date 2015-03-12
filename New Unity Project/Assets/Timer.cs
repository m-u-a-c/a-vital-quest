using UnityEngine;
using System.Collections;
using System.Threading;

public class Timer : MonoBehaviour {

    float timeleft;
    float ticktime;
    public int ticks;
    public int maxticks;
    public bool running;
    System.Action action = null;
    System.Func<bool> condition = null;
    //Sets the timer with an interval specified in seconds, amount of ticks, method to call
    //Also starts the timer
    //Don't forget to add the timer as a component to a GameObject in order for it to work
    public void SetTimer(float Interval, int Ticks, System.Action Action = null, System.Func<bool> Condition = null)
    {
        timeleft = Interval;
        ticktime = Interval;
        if (Ticks != 0)
		    maxticks = Ticks;
		else
		    maxticks = int.MaxValue;
        running = true;
        action = Action;
        condition = Condition;
    }

    public void PauseTimer()
    {
        running = false;
    }

    public void StopTimer()
    {
        running = false;
        timeleft = ticktime;
        ticks = 0;
    }

    public void StartTimer()
    {
        running = true;
    }


	// Update is called once per frame
	void Update () {
        
	    if (running)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0)
            {
                ticks++;
                if (condition != null) running = condition();
                timeleft = ticktime;
                if (action != null) action();
            }
        }
        if (ticks >= maxticks) StopTimer();
	}
}
