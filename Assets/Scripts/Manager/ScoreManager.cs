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
    private ScriptableEvent youwin;
    [SerializeField]
    int Score = 10;

    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ScoreText.text = "Enemies to Kill: " + Score.ToString();
    }

    public void AddPoint()
    {
        Score -= 1;
        ScoreText.text ="Enemies to Kill: "+ Score.ToString();
    }
   
    private void Update()
    {
        
        if (Score < 1)
        {
            Szeneloader.Instance.LoadScene(Szeneloader.GetNextScene());

            youwin.RaiseEvent();
        }
        
    }
}
