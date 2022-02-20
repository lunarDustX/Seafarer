using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerEnd;

    public void CreateTimer(int _seconds)
    {
        Invoke("TimerEnd", _seconds);
    }

    void TimerEnd()
    {
        if (OnTimerEnd != null)
            OnTimerEnd.Invoke();
    }
}
