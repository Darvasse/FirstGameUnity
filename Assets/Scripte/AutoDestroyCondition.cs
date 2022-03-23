using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyCondition : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().GetGrounded()&& GameObject.FindGameObjectWithTag("SpawnPos")!=null) 
        {
            Destroy(gameObject);
        }
    }
}
