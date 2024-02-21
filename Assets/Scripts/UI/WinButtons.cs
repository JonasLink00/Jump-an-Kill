using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButtons : MonoBehaviour
{
    public void BacktoMain()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.MainMenu);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
