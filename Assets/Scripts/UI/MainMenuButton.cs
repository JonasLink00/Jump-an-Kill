using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public static SceneIndicies nextScene;
    public void StartGame()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.Tutorial);
        
    }

    public void OptionsButton()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.Options, LoadSceneMode.Additive);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
