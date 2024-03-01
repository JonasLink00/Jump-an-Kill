using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    //legt fest welche Szene bei Starten der Konsole geladen wird
    public static SceneIndicies nextScene;

    //legt fest was passiert wenn ein Button gedrückt wird (Läd entsprechenede Szene)
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
