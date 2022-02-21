using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                AudioManager.Play(AudioClipName.MenuButtonClick);
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Help:
                AudioManager.Play(AudioClipName.MenuButtonClick);
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Pause:

                if (Time.timeScale == 1)
                {
                    AudioManager.Play(AudioClipName.MenuButtonClick);
                    Object.Instantiate(Resources.Load("PauseMenu"));
                }
                break;
        }
    }

}
