using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    
    public string SceneName1,SceneName2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneName1,LoadSceneMode.Single);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName2, LoadSceneMode.Single);
    }
}
