using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButton : MonoBehaviour
{
    //legt fest was passiert wenn ein Button gedrückt wird (Läd entsprechenede Szene)

    public void PlayButton()
    {
        Szeneloader.Instance.UnLoadScene(SceneIndicies.PauseMenu);
        Time.timeScale = 1.0f;
        GameManager.Instance.GameisPaused = false;


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
