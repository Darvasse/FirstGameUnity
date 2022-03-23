using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacleController : MonoBehaviour
{
    Rigidbody2D objRigidbody;
    private void Start()
    {
        objRigidbody=GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            objRigidbody.gravityScale =1f;
        }
    }
}
