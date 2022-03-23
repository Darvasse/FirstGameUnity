using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy1Controller : MonoBehaviour
{
    Rigidbody2D EnnemyRB;
    SpriteRenderer EnnemySR;
    Animator EnnemyAC;
    public GameObject Damage;
    bool facingRight = true,CanMove=true,IsInAttackMode=false,IsDead=false;
    public float maxSpeed;
    int direction=1;
    // Start is called before the first frame update
    void Start()
    {
        EnnemyRB = GetComponent<Rigidbody2D>();
        EnnemySR=GetComponent<SpriteRenderer>();
        EnnemyAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsDead)
        {
            if (facingRight && EnnemyRB.velocity.x > 0)
            {
                Flip();
            }
            else if (!facingRight && EnnemyRB.velocity.x < 0)
            {
                Flip();
            }
            if (CanMove)
            {
                EnnemyRB.velocity = new Vector2(maxSpeed * direction, EnnemyRB.velocity.y);
            }
            else
            {
                EnnemyRB.velocity = new Vector2(0 * direction, EnnemyRB.velocity.y);
            }
            if (EnnemyRB.velocity.normalized != new Vector2(0, 0))
            {
                EnnemyAC.SetBool("IsMooving", true);
            }
            else
            {
                EnnemyAC.SetBool("IsMooving", false);
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        EnnemySR.flipX = !EnnemySR.flipX;
    }
    public void ChangeDirection()
    {
        if (direction == -1)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
    public void TriggerCanMove()
    {
        CanMove = !CanMove;
    }
    public void SetAttackMode()
    {
        if (!IsInAttackMode)
        {
            IsInAttackMode = !IsInAttackMode;
            //TriggerCanMove();
            CanMove = false;
            EnnemyAC.SetBool("IsAttacking", true);
        }
        else
        {
            IsInAttackMode = !IsInAttackMode;
            //TriggerCanMove();
            CanMove = true;
            EnnemyAC.SetBool("IsAttacking", false);
        }
    }
    public void EnnemyAttack1()
    {
        Instantiate(Damage, new Vector3(transform.position.x+2f,transform.position.y- 1.732439f, transform.position.z), Quaternion.identity);
    }
    public void EnnemyAttack2()
    {
        Instantiate(Damage, new Vector3(transform.position.x - 1.5f, transform.position.y - 1.740439f, transform.position.z), Quaternion.identity) ;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            EnnemyRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            collision.gameObject.GetComponent<playerController>().Knockback(this.gameObject);
            collision.gameObject.GetComponent<playerController>().Damagetaken();
            collision.gameObject.GetComponent<PlayerInventory2>().LowerHealth();
        }
        else if(collision.collider.tag== "VilainPasBeau")
        {
            ChangeDirection();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            EnnemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    public void Dying()
    {
        IsDead = true;
        EnnemyAC.SetBool("IsDead", true);
    }
}
