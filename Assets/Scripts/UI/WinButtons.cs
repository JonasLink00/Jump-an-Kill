using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButtons : MonoBehaviour
{
    //legt fest was passiert wenn ein Button gedrückt wird (Läd entsprechenede Szene)
    public void BacktoMain()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.MainMenu);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
