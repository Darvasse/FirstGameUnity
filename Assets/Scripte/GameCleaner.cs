using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCleaner : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory2>().LowerHealth();
            collision.GetComponent<playerController>().Damagetaken();
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("SpawnPos").transform.position;
        }
        if(collision.tag == "Obstacle"||collision.tag=="NoArmOsbtacle")
        {
            Destroy(collision.gameObject);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
    
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
    }

    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level_3", LoadSceneMode.Single);
    }
    
    public void SelectOptionLevel()
    {
        SceneManager.LoadScene("Option_Scene", LoadSceneMode.Single);
    }
    
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
