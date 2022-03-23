using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().Knockback(this.gameObject);
            collision.gameObject.GetComponent<playerController>().Damagetaken();
            collision.gameObject.GetComponent<PlayerInventory2>().LowerHealth();
        }
    }
}
