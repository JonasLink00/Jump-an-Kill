
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] private ScriptableEvent timeisup;

    [SerializeField]
    private ScriptableEvent ShowCountdown;
    [SerializeField]
    private ScriptableEvent StopTimer;
    public static bool timerisstoped = false;
    public Countdowntimer Countdown;

    [SerializeField]
    Animator _animator;
    private void Update()
    {
        //Updated Timer und löst Event aus
        if (remainingTime > 6 && !timerisstoped)
        {
            remainingTime -= Time.deltaTime;
           
        }
        else if (remainingTime < 6)
        {
            Debug.Log("Countdown");
            ShowCountdown.RaiseEvent();
            Animatetimer();
            Countdown.ShowCountdown();
        }
        //legt fest wie der Timer angezeigt wird
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void Animatetimer()
    {
        _animator.SetBool("Countdown", true);
    }

}
