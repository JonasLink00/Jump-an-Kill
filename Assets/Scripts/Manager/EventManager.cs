using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public void TimeisUpEvent()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.GameOver);
    }
    public void LevelCompleteEvent()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.Level1);
    }
    public void YouWinEvent()
    {
        Szeneloader.Instance.LoadScene(SceneIndicies.Win);
    }
}
