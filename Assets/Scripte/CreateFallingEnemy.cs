using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFallingEnemy : MonoBehaviour
{
    public GameObject Falling;
    public float CreateTimer;
    public float apparitiontimer;
    bool Inside=false;
    void Start()
    {
        InvokeRepeating("spawnEnnemy", apparitiontimer, CreateTimer);
    }
    //void Update()
    //{
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Inside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Inside = false;
        }
    }
    public void spawnEnnemy()
    {
        if (Inside)
        {
            Instantiate(Falling, transform.position, Quaternion.identity);
        }
    }
}
