using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingTrigger : MonoBehaviour
{
    public GameObject Parentobj;
    public GameObject Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Parentobj.GetComponent<Ennemy1Controller>().SetAttackMode();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Parentobj.GetComponent<Ennemy1Controller>().SetAttackMode();
        }
    }
    
}
