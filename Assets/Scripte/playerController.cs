using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour
{


    Animator anim;
    Rigidbody2D playerRB; // Propriété qui tiendra en réféence le rigid body de notre player
    SpriteRenderer playerRenderer; // Propriété qui tiendra la réféence du sprite rendered de notre player
    CapsuleCollider2D playerCollider;
    public GameObject Damage;
    public GameObject RespawnJump;
    public GameObject PlayerAttack;
    bool facingRight = true; // Par défaut, notre player regarde à droite
    bool isRunning;
    Vector3 localScale;
    //float dirX = 5f;
    public float maxSpeed; // Vitesse maximale que notre player peut atteindre en se déplacant
    public float knock;
    float move;
    public float jumpPower;//ajouter un jump boost
    public bool grounded = false;
    public bool DoubleJump = true;
    bool DashUsed = false;
    public float DashPower;
    float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool InvokeDashOnce = true;
    bool InvokeDJumpOnce = true;
    public float HurtTime;
    bool isHurt = false;
    bool canMove = true,animattack =true;

    //private Vector3 lastMoveDir;

    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se situe au sein du même objet
        anim = GetComponent<Animator>();
        localScale = transform.localScale;


        // Récupérer le component sprite renderer en dessous de cette ligne
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove && grounded&&Input.GetAxis("Jump") > 0)
        {
            DoubleJump = false;
            anim.SetBool("IsGrounded", false);
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            if (InvokeDJumpOnce)
            {
                Invoke("toggleDoubleJump", 0.3f);
                InvokeDJumpOnce = false;
            }
            
        }
        if (canMove && !grounded && DoubleJump && (Input.GetAxis("Jump") > 0))
        {
            DoubleJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        if (canMove && !grounded&&!DashUsed&&Input.GetAxis("Dash")>0) 
        {
            Vector3 Dash = new Vector3(DashPower,0.0f);
            playerRB.AddForce(Dash* 100 *playerRB.velocity.normalized);
            anim.SetBool("isDashing", true);
            if (InvokeDashOnce)
            {
                Invoke("toggleDash", 0.2f);
            }
            InvokeDashOnce = false;
            //DashUsed = true;
        }
        if (grounded)
        {
            DashUsed = false;
            DoubleJump = false;
            InvokeDashOnce = true;
            InvokeDJumpOnce = true;
        }
        anim.SetFloat("VerticalVelocity", playerRB.velocity.y);
        anim.SetBool("IsGrounded", grounded);
        if (canMove)
        {
            move = Input.GetAxis("Horizontal");
        }
        else move = 0;
        IsHeMooving(move);
        if (facingRight && move < 0)
        {
            Flip();
        }
        if (!facingRight && move > 0)
        {
            Flip();
        }
        playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y); // On utilise vector 2 car nous sommes dans un contexte 2D
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("IsAttacking",true);
            animattack = false;
            if (facingRight)
            {
                Instantiate(PlayerAttack, new Vector3(transform.position.x+0.75f, transform.position.y, transform.position.z), Quaternion.identity); 
            }
            else
            {
                Instantiate(PlayerAttack, new Vector3(transform.position.x-0.75f, transform.position.y, transform.position.z), Quaternion.identity);
            }
            canMove = false;        }
        else if(gameObject.GetComponent<PlayerInventory2>().GetHealth()>0&&!canMove&&animattack)
        {
            canMove = !canMove;
            anim.SetBool("IsAttacking", false);
        }
    }
    public void IsAttackEnd()
    {
        animattack = true;
    }
    public bool GetGrounded() { return grounded; }
    public void togglecanMove()
    {
        canMove = !canMove;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    public void toggleIsHurt()
    {
        isHurt = !isHurt;
    }

    public void toggleDoubleJump()
    {
        DoubleJump = true;
    }
    public void toggleDash()
    {
        DashUsed = !DashUsed;
        anim.SetBool("isDashing", false);
    }
    void Flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire, représentant la direction du personnage
        playerRenderer.flipX = !playerRenderer.flipX; // Même chose ici pour que notre flipx et facingRight soient en phase
    }
    void IsHeMooving(float move)
    {
        if (move == 0) { anim.SetBool("isRunning", false); }
        else if (move != 0) { anim.SetBool("isRunning", true); }
    }
    public void animDead()
    {
        anim.SetBool("isDead", true);
    }
    public void Knockback(GameObject go)
    {
        if (canMove)
        {
            toggleIsHurt();
            //toggleCanMove();
            //playerAnim.SetBool("isWalking", false);
            Vector3 saut = new Vector3(4.5f, 0.2f);
            playerRB.AddForce(saut * 1000 * -knock /*-playerRB.velocity.normalized*/);
            //Invoke("toggleCanMove", HurtTime);
            Invoke("toggleIsHurt", HurtTime);
        }
    }
    public void Damagetaken()
    {
        Instantiate(Damage, transform.position, Quaternion.identity);
    }
    public void UpdateRespawn()
    {
        RespawnJump.transform.position = gameObject.transform.position;
    }
}