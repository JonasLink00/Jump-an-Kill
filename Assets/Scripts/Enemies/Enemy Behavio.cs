using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("EnemyCheck")]
    public Transform enemyCheckPos;
    public Vector2 enemyCheckSize = new Vector2(0.5f, 0.05f);

    public PlayerMovment Player;

    public bool moveright = true;
    [SerializeField]
    private float Speed = 2f;

    [SerializeField]
    int destoryTime = 6;

    AudioSource DestroyEnemySound;

    [SerializeField]
    private ParticleSystem EnemyExplosion;

    private void Start()
    {
        Player = FindObjectOfType<PlayerMovment>();
        DestroyEnemySound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        EnemyMovement();
        Destroy(gameObject, destoryTime);
    }

    //Konstante Bewegung nach Rechts

    private void EnemyMovement()
    {
        if(moveright)
        {
            transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * Speed;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<Rigidbody2D>() != null && Player.isJumping)
        {
            StopCoroutine(DestroyEnemy());
            StartCoroutine(DestroyEnemy());
            EnemyExplosion.Play();
            DestroyEnemySound.Play();
        }
    }
  

    //Entfernt GameObjekt
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.2f);
        ScoreManager.instance.AddPoint();
        Destroy(gameObject);
    }

    //Zeichnet HitBock 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(enemyCheckPos.position, enemyCheckSize);
    }
}
