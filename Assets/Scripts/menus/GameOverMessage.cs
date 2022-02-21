using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        messageText.text = "Game Over!\n\nScore: " + score;
    }

    public void HandleQuitButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        Destroy(gameObject);
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
    }
}
