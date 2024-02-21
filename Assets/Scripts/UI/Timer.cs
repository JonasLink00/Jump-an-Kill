using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] private ScriptableEvent timeisup;

    private void Update()
    {
       
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
           
        }
        else
        {
            remainingTime = 0;
            timeisup.RaiseEvent();
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    

}
