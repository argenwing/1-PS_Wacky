using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    #region Fields

    Text scoreText;
    int score = 0;
    const string scoreTextPrefix = "Score: ";

    Text ballsLeftText;
    int ballsleft;
    const string ballsLeftPrefix = "Balls Left: ";

    LastBallLost lastBall;

    #endregion

    public int Score
    {
        get { return score; }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = scoreTextPrefix + score;

        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        ballsleft = ConfigurationUtils.BallsPerGame;
        ballsLeftText.text = ballsLeftPrefix + ballsleft;

        EventManager.AddPointsAddedListener(AddPoints);
        EventManager.AddReduceBallListener(ReduceBall);

        lastBall = new LastBallLost();
        EventManager.AddLastBallLostInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBall.AddListener(listener);
    }

    void AddPoints(int points)
    {
        score += points;
        scoreText.text = scoreTextPrefix + score;
    }

    void ReduceBall()
    {
        ballsleft --;
        ballsLeftText.text = ballsLeftPrefix + ballsleft;
        if (ballsleft == 0)
        {
            lastBall.Invoke();
        }
    }
}
