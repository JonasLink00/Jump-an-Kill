using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
    public int jumpsRemaning;
    bool pressedJump = false;
    public bool secondJump = false;
    AudioSource jumpSound;
    [SerializeField]
    private ParticleSystem JumpDust;

    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    public bool isGrounded = false;


    
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
        ManageJump();
        Gravity();
        Flip();
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        //Steuert die Animationen 
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
        if (jumpsRemaning <= 0) return;

        if (context.performed)
        {
           pressedJump = true;
        }
        else
        {
            pressedJump = false;
        }
        
    }
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            
            isGrounded = true;
            secondJump = false;
            
            Debug.Log("Grounded");
           
        }
        else
        {
            Debug.Log("notGrounded");

            isGrounded = false;
        }

    }
    
    private void JumpReset()
    {
        jumpsRemaning = maxJumps;
        _animator.SetBool("jumping", false);
        _sprite.color = Color.white;
    }

    private void SetJumpAnimation()
    {
        _animator.SetBool("jumping", true);
        _sprite.color = Color.yellow;
    }

    private void ManageJump()
    {
        if(pressedJump)
        {
            SetJumpAnimation();

            if (!secondJump)
            {
                Debug.Log("JUmp1");
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsRemaning--;
                jumpSound.Play();
                JumpDust.Play();
                secondJump = true;

            }
            else if (secondJump)
            {
                Debug.Log("JUmp2");
                rb.velocity = new Vector2(rb.velocity.x, jumpPower * 1.2f);
                jumpsRemaning--;
                jumpSound.Play();
                JumpDust.Play();
                secondJump = false;
            }
        }
        else
        {
            Debug.Log("JumpReset");
            JumpReset();
           
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
        //Zeichnet Box f�r GroundCheck
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
