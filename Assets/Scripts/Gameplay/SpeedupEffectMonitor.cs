using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedupTimer;
    float speedupFactor;

    // Start is called before the first frame update
    void Start()
    {
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(HandleSpeedupTimerFinished);
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SpeedupActive
    {
        get { return speedupTimer.Running; }
    }

    public float SpeedupTimeLeft
    {
        get { return speedupTimer.SecondsLeft; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    /// <summary>
    /// Handle when speedup effect take effects
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="factor"></param>
    void HandleSpeedupEffectActivatedEvent(float duration, float factor)
    {
        if (!speedupTimer.Running)
        {
            speedupFactor = factor;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    void HandleSpeedupTimerFinished()
    {
        speedupTimer.Stop();
        AudioManager.Play(AudioClipName.SpeedupEffectDeactivated);
        speedupFactor = 1;
    }
}
