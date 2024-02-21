using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviorLeft : MonoBehaviour
{
    [Header("EnemyCheck")]
    public Transform enemyCheckPos;
    public Vector2 enemyCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask enemyLayer;


    [SerializeField]
    private float Speed = 2f;

    [SerializeField]
    int destoryTime = 5;

    private void Update()
    {
        EnemyCheck();
        EnemyMovement();
        Destroy(gameObject, destoryTime);

    }

    //Konstante Bewegung nach Rechts

    private void EnemyMovement()
    {
        transform.position += Vector3.left * Time.deltaTime * Speed;
    }

    //Checkt ob das Objekt des Spieler berührt
    private void EnemyCheck()
    {
        if (Physics2D.OverlapBox(enemyCheckPos.position, enemyCheckSize, 0, enemyLayer))
        {
            StopCoroutine(DestroyEnemy());
            StartCoroutine(DestroyEnemy());
        }


    }

    //Entfernt GameObjekt
    IEnumerator DestroyEnemy()
    {
        Debug.Log("EnemyFound");
        yield return new WaitForSeconds(0.2f);
        ScoreManager.instance.AddPoint();
        Destroy(this.gameObject);
    }

    //Zeichnet HitBock 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(enemyCheckPos.position, enemyCheckSize);
    }
}
