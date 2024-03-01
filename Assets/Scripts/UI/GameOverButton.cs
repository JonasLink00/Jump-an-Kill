using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    //legt fest was passiert wenn ein Button gedrückt wird (Läd entsprechenede Szene)

    public void Restart()
    {
        //GameManager.Instance.ResetPoints();
        Szeneloader.Instance.LoadScene(SceneIndicies.Level1);

    }

    public void Menu()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
