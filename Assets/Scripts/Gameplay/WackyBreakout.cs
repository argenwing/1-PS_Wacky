using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakout : MonoBehaviour
{

    private void Start()
    {
        EventManager.AddLastBallLostListener(HandleLastBallLost);
        EventManager.AddAllBlockDestroyedListener(HandleAllBlockDestroyed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    void HandleLastBallLost()
    {
        AudioManager.Play(AudioClipName.GameLost);
        EndGame();
    }

    void HandleAllBlockDestroyed()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameObject endGameMessage = Instantiate(Resources.Load("GameOverMessage")) as GameObject;
        GameOverMessage gameOverMessageScript = endGameMessage.GetComponent<GameOverMessage>();
        GameObject hudObject = GameObject.FindGameObjectWithTag("HUD");
        HUD hudScript = hudObject.GetComponent<HUD>();
        gameOverMessageScript.SetScore(hudScript.Score);
    }
}
