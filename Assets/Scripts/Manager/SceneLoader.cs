using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneIndicies
{
    //Alle Scenen sind in der selben reihnfolge wie in Build Settings
   MainMenu,
   Tutorial,
   Level1,
   Level2,
   SampleScene,
   Win,
   PauseMenu,
   Options,
   GameOver
   
}
public class Szeneloader : MonoBehaviour
{
    [SerializeField]
    private SceneIndicies startScene;
    public static Szeneloader Instance;

    private void Awake()
    {
        //Verhindert, dass zwei Szeneloader in einer Scene existieren 
        if (Instance == null && Instance != this)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        LoadScene(startScene);
    }

    //Läd Scenen mit Hilfe des Indicies
    public void LoadScene(SceneIndicies _indicies, LoadSceneMode _mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene((int)_indicies, _mode);

    }

    //Unläd Scenen mit Hilfe des Indicies
    public void UnLoadScene(SceneIndicies _indicies)
    {
        SceneManager.UnloadSceneAsync((int)_indicies);
    }

    //Läd die Scenen die im Enum nach der Aktuellen kommt 
    public static SceneIndicies GetNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        return (SceneIndicies)nextScene;
    }
    
}
