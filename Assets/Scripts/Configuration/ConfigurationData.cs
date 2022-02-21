using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 250;
    static float ballLifeSeconds = 10;
    static float minSpawnSeconds = 5;
    static float maxSpawnSeconds = 10;
    static int standardBlockPoints = 1;
    static int bonusBlockPoints = 2;
    static int pickupBlockPoints = 5;
    static float standardProbability = 0.6f;
    static float bonusProbability = 0.3f;
    static float freezerProbability = 0.05f;
    static float speedupProbability = 0.05f;
    static int ballsPerGame = 10;
    static float freezerSeconds = 1;
    static float speedupSeconds = 1;
    static float speedupFactor = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the number seconds of the ball lives
    /// </summary>
    /// <value>ball life as seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    public float StandardProbability
    {
        get { return standardProbability; }
    }

    public float BonusProbability
    {
        get { return bonusProbability; }
    }

    public float FreezerProbability
    {
        get { return freezerProbability; }
    }

    public float SpeedupProbability 
    {
        get { return speedupProbability; }
    }

    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public float FreezerSeconds
    {
        get { return freezerSeconds; }
    }

    public float SpeedupSeconds
    {
        get { return speedupSeconds; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            //create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            //read names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            //set fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    /// <summary>
    /// Set configuration data fields from provided
    /// </summary>
    /// <param name="cssValues"></param>
    void SetConfigurationDataFields (string cssValues)
    {
        // assuming that know the order of values appear in the string
        string[] values = cssValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeSeconds = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardProbability = float.Parse(values[8]);
        bonusProbability = float.Parse(values[9]);
        freezerProbability = float.Parse(values[10]);
        speedupProbability = float.Parse(values[11]);
        ballsPerGame = int.Parse(values[12]);
        freezerSeconds = float.Parse(values[13]);
        speedupSeconds = float.Parse(values[14]);
        speedupFactor = float.Parse(values[15]);
    }

    #endregion
}
