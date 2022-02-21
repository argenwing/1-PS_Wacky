using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpluseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeSeconds
    {
        get { return configurationData.BallLifeSeconds; }
    }

    public static float MinSpawnSeconds
    {
        get { return configurationData.MinSpawnSeconds; }
    }

    public static float MaxSpawnSeconds
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static int PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    public static float StandardProbability
    {
        get { return configurationData.StandardProbability; }
    }

    public static float BonusProbability
    {
        get { return configurationData.BonusProbability; }
    }

    public static float FreezerProbability
    {
        get { return configurationData.FreezerProbability; }
    }

    public static float SpeedupProbability
    {
        get { return configurationData.SpeedupProbability; }
    }

    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    public static float FreezerSeconds
    {
        get { return configurationData.FreezerSeconds; }
    }

    public static float SpeedupSeconds
    {
        get { return configurationData.SpeedupSeconds; }
    }

    public static float SpeedupFactor
    {
        get { return configurationData.SpeedupFactor; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
