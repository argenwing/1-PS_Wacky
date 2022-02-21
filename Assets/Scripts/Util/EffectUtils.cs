using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    
    public static bool SpeedupActive
    {
        get { return GetSpeedupEffectMonitor().SpeedupActive; }
    }

    public static float SpeedupTimeLeft
    {
        get { return GetSpeedupEffectMonitor().SpeedupTimeLeft; }
    }

    public static float SpeedupFactor
    {
        get { return GetSpeedupEffectMonitor().SpeedupFactor; }
    }

    static SpeedupEffectMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffectMonitor>();
    }
}
