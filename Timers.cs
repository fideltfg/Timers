using System;
using System.Collections.Generic;
using UnityEngine;

public class Timers : MonoBehaviour
{
    // Singleton instance
    public static Timers Instance;

    // Dictionary to store timers sorted by expiration time
    SortedDictionary<float, Timer> _timers = new SortedDictionary<float, Timer>();

    // Current time
    float time = 0;

    // Awake is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        List<float> expiredTimerKeys = new List<float>();

        // Iterate over timers and check for expired ones
        foreach (var kvp in _timers)
        {
            float key = kvp.Key;
            Timer timer = kvp.Value;

            if (timer.StartTime + timer.Duration < time)
            {
                timer.Callback();
                expiredTimerKeys.Add(key);
            }
        }

        // Remove expired timers
        for (int i = 0; i < expiredTimerKeys.Count; i++)
        {
            _timers.Remove(expiredTimerKeys[i]);
        }

        // Reset time if no active timers
        if (_timers.Count == 0)
        {
            time = 0;
        }
    }

    // Set a timer with a given duration and callback function
    public void SetTimer(float duration, Action callback)
    {
        _timers.Add(time + duration, new Timer(time, duration, callback));
    }
}

// Struct to represent a timer
public struct Timer
{
    public float StartTime;
    public float Duration;
    public Action Callback;

    public Timer(float startTime, float duration, Action callback)
    {
        StartTime = startTime;
        Duration = duration;
        Callback = callback;
    }
}
