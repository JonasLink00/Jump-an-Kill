using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneIndicies
{
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

    public void LoadScene(SceneIndicies _indicies, LoadSceneMode _mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene((int)_indicies, _mode);

    }

    public void UnLoadScene(SceneIndicies _indicies)
    {
        SceneManager.UnloadSceneAsync((int)_indicies);
    }

    public static SceneIndicies GetNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        return (SceneIndicies)nextScene;
    }
    
}
