﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Countdowntimer
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float remainingTime;
        [SerializeField] private ScriptableEvent timeisup;

        public static bool timerisstoped = false;
        private void Update()
        {
            //Updated Timer und löst Event aus
            if (remainingTime > 0 && !timerisstoped)
            {
                remainingTime -= Time.deltaTime;

            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                timeisup.RaiseEvent();
            }
            //legt fest wie der Timer angezeigt wird
            //int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{00}", seconds);
        }
    }
}