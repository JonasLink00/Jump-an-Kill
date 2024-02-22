using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    public bool GameisPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
   // public float GetPoints()
   // {
   //     return EnenmiestoKill;
   // }
   // public void ResetPoints()
   // {
   //     EnenmiestoKill = 10f;
   // }
   // public void AddPoints(float amount)
   // {
   //     EnenmiestoKill -= amount;
   // }

}
