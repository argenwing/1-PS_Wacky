using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = new List<UnityAction<float>>();

    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectListeners = new List<UnityAction<float, float>>();

    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners = new List<UnityAction<int>>();

    static List<Ball> reduceBallInvokers = new List<Ball>();
    static List<UnityAction> reduceBallListeners = new List<UnityAction>();

    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();

    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners = new List<UnityAction>();

    static List<Block> allBlockDestroyedInvokers = new List<Block>();
    static List<UnityAction> allBlockDestroyedListeners = new List<UnityAction>();

    public static void AddAllBlockDestroyedInvoker(Block invoker)
    {
        allBlockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in allBlockDestroyedListeners)
        {
            invoker.AddAllBlockDestroyedListener(listener);
        }
    }

    public static void AddAllBlockDestroyedListener(UnityAction listener)
    {
        allBlockDestroyedListeners.Add(listener);
        foreach(Block invoker in allBlockDestroyedInvokers)
        {
            invoker.AddAllBlockDestroyedListener(listener);
        }
    }

    public static void AddLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void AddReduceBallInvoker(Ball invoker)
    {
        reduceBallInvokers.Add(invoker);
        foreach (UnityAction listener in reduceBallListeners)
        {
            invoker.AddReduceBallListener(listener);
        }
    }

    public static void AddReduceBallListener(UnityAction listener)
    {
        reduceBallListeners.Add(listener);
        foreach (Ball invoker in reduceBallInvokers)
        {
            invoker.AddReduceBallListener(listener);
        }
    }

    public static void AddPointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedListeners.Add(listener);
        foreach (Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        freezerEffectInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectListeners.Add(listener);
        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    public static void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectListeners.Add(listener);
        foreach (PickupBlock invoker in speedupEffectInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }
}
