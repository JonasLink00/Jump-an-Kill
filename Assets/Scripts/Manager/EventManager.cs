using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //Event bei ablauf der Zeit
    public void TimeisUpEvent()
    {
        Debug.Log("Game Over");
        Szeneloader.Instance.LoadScene(SceneIndicies.GameOver);
    }
    
}
