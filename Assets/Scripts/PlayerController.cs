using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public Transform grounCheck;
    public float groundCheckRadius;
    public Color drainedColor;
    public Color originalColor;
    public LayerMask groundLayer;
    public GameObject deathPlane;
    public HealthPresenter healthBar;
    private bool isTouchingGround;
    private bool jumpButton = false;
    private bool rightButton = false;
    private bool leftButton = false;
    private float direction = 0f;
    private Rigidbody2D player;
    private Animator animation;
    private SpriteRenderer sprite;
    [SerializeField] private AudioSource jumpSoundEffect;
    private Vector3 respawnPoint;
    private enum MovementState {idle, running, jumping, falling }; 

    void Start()
    {
        Health.totalHealth = 1f;
        player = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        respawnPoint = transform.position;
        originalColor = sprite.color;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Jump") && isTouchingGround) || (isTouchingGround && jumpButton))
        {
            jumpSoundEffect.Play();
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        UpdateHandleState();
        deathPlane.transform.position = new Vector2(transform.position.x,deathPlane.transform.position.y);
        jumpButton = false;

        


    }

    public void JumpButtonClick()
    {
        jumpButton = true;
    }

    public void RightButtonDown()
    {
        rightButton = true;
    }

    public void LeftButtonDown()
    {
        leftButton = true;
    }

    public void RightButtonUp()
    {
        rightButton = false;
    }

    public void LeftButtonUp()
    {
        leftButton = false;
    }

    void UpdateHandleState()
    {
        MovementState state;
        isTouchingGround = Physics2D.OverlapCircle(grounCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        if(rightButton == true)
        {
            direction = 1f;
            
        }
        else if(leftButton == true)
        {
            direction = -1f;
        }

        
        
        if (direction > 0f || rightButton == true)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (direction < 0f || leftButton== true)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
            state = MovementState.idle;
        }
        if (player.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if(player.velocity.y < 0.1f && isTouchingGround == false)
        {
            state = MovementState.falling;
        }

        animation.SetInteger("currentState", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Death Plane"))
        {
            transform.position = respawnPoint;
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard")){
            healthBar.Damage(0.002f);
        }
        if (collision.CompareTag("Health Drain Hazard"))
        {
            healthBar.Damage(0.002f);
            sprite.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = originalColor;
    }
}
