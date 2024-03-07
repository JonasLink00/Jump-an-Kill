using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static System.TimeZoneInfo;



    public class Countdowntimer: MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float remainingTime;
        [SerializeField] private ScriptableEvent timeisup;

        public static bool timerisstoped = false;

        [SerializeField]
        Animator transition;

        [SerializeField]
        float transitionTimer = 1f; 
    public void ShowCountdown()
        {
            //Updated Timer und löst Event aus
            if (remainingTime > 0 && !timerisstoped)
            {
                remainingTime -= Time.deltaTime;

            }
            else if (remainingTime < 1)
            {
                timeisup.RaiseEvent();
                remainingTime = 0;
            }
            //legt fest wie der Timer angezeigt wird
            //int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{00}", seconds);
        }
    private void Update()
    {
        //Scenenwecksel bei abgearbeitetem Score
        if (remainingTime < 1)
        {
            StartCoroutine(LoadTransition());
        }

    }
    //Tiggerd beim Aufrufen die Transition + neue Scene
    IEnumerator LoadTransition()
    {
        Timer.timerisstoped = true;
        transition.SetTrigger("Start");


        yield return new WaitForSeconds(transitionTimer);

        Szeneloader.Instance.LoadScene(SceneIndicies.GameOver);

    }
}

