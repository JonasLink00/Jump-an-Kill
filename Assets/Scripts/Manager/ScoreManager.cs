using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI ScoreText;
    [SerializeField]
    int Score = 10;

    [SerializeField]
    Animator transition;

    [SerializeField]
    float transitionTimer = 1f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Zeigt den zu erreichenden Score
        ScoreText.text = "Enemies to Kill: " + Score.ToString();
    }

    public void AddPoint()
    {
        //Zählt den Score runter wenn Gegner besiegt werden 
        Score -= 1;
        ScoreText.text ="Enemies to Kill: "+ Score.ToString();
    }
   
    private void Update()
    {
        //Scenenwecksel bei abgearbeitetem Score
        if (Score < 1)
        {
           StartCoroutine(LoadTransition());
        }
        
    }
    //Tiggerd beim Aufrufen die Transition + neue Scene
    IEnumerator LoadTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTimer);

        Szeneloader.Instance.LoadScene(Szeneloader.GetNextScene());

    }
}
