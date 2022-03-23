using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VilainPasBeau")
        {
            collision.gameObject.GetComponent<Ennemy1Controller>().Dying();
            Destroy(collision.gameObject, 1);
        }
    }
}
