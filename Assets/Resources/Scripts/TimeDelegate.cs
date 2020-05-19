using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelegate
{
    #region Singleton
    private static TimeDelegate Instance;
    static TimeDelegate() { }
    public static TimeDelegate instance { get { return Instance ?? (Instance = new TimeDelegate()); } }
    #endregion

    public List<TimerFunction> collection;
    public void Initialize() {
        collection = new List<TimerFunction>();
    }
    public void PostInitialize() { }
    public void Refresh(float dt) {
        for (int i = collection.Count-1; i >=0 ; i--)
        {
            collection[i].timeRemain -= dt;
            if (collection[i].timeRemain <= 0)
            {
                collection[i].invokeAction.Invoke();
                collection.Remove(collection[i]);
            }

        }
    
    }
    public void PhysicsRefresh(float fdt) { }
    public void Action(Action a, float t)
    {
        TimerFunction timerFunction = new TimerFunction();
        timerFunction.invokeAction = a;
        timerFunction.timeRemain = t;
        collection.Add(timerFunction);

    }


}

public class TimerFunction
{
    public Action invokeAction;
    public float timeRemain;

}



