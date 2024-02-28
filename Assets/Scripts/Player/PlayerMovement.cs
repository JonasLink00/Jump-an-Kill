using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{

    public Rigidbody2D rb;
    bool isFacingRight = true;
    [Header("Movement")]
    public float PlayerSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2;
    int jumpsRemaning;
    public bool isJumping = false;
    AudioSource jumpSound;
    [SerializeField]
    private ParticleSystem JumpDust;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    public bool isGrounded = false;

    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    
    public SpriteRenderer _sprite;
    public bool _isFacingRight = true;

    [SerializeField]
    Animator _animator;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        jumpsRemaning = maxJumps;
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(horizontalMovement * PlayerSpeed, rb.velocity.y);
        GroundCheck();
        Gravity();
        Flip();
        
    }

    public void Move(InputAction.CallbackContext context)
    {

        if(context.canceled)
        {
            _animator.SetBool("walking", false);
        }
        else
        {
            _animator.SetBool("walking", true);
        }

        //Bewegt den Player auf horizontaler Ebene 
        if (horizontalMovement > 0 && !_isFacingRight || horizontalMovement < 0 && _isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            _sprite.flipX = !_sprite.flipX;
        }
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void Gravity()
    {
        //Fallgeschwindigkeit wird angapasst
        if(rb.velocity.y < 0) 
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; // Fall incresaingly faster
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
   
    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaning > 0)
        {
            isJumping = true;

            

            //Performed = Komplet gedrückt = 1 Jump
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsRemaning--;
                jumpSound.Play();
                JumpDust.Play();

            }
            //Canceld = nicht Komplet gedrückt = 0,5 Jump
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                jumpsRemaning--;
                
            }


        }
    }
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaning = maxJumps;
            isGrounded = true;
            isJumping = false;
            _animator.SetBool("jumping", false);
            _sprite.color = Color.white;


            //Verändert das Layer
            int PlayerLayer = LayerMask.NameToLayer("Player");
            gameObject.layer = PlayerLayer;
            //Debug.Log("Current layer:" + gameObject.layer);
        }
        else if (isJumping)
        {

            isGrounded = false;

            _animator.SetBool("jumping", true);
            _sprite.color = Color.yellow;
            //Verändert das Layer
            int AttackLayer = LayerMask.NameToLayer("Attack");
            gameObject.layer = AttackLayer;
            //Debug.Log("Current layer:" + gameObject.layer);

        }

    }
    
    
    private void Flip()
    {
        //Spieler guckt in Richtung der Bewegung
        if (isFacingRight && horizontalMovement < 0 || isFacingRight && horizontalMovement > 0) 
        {
            isFacingRight = !_isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    
    public void Pause(InputAction.CallbackContext context)
    {
        
        if(!GameManager.Instance.GameisPaused)
        {
            Szeneloader.Instance.LoadScene(SceneIndicies.PauseMenu, LoadSceneMode.Additive);
            Time.timeScale = 0f;
            GameManager.Instance.GameisPaused = true;
        }
       
        
    }
    private void OnDrawGizmosSelected()
    {
        //Zeichnet Box für GroundCheck
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
