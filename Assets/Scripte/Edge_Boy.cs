using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge_Boy : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VilainPasBeau")
        {
            collision.gameObject.GetComponent<Ennemy1Controller>().ChangeDirection();
        }
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().UpdateRespawn();
        }
    }
}
