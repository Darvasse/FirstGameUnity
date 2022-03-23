using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory2 : MonoBehaviour
{
    /*public Text coinText;
    public Text lifeText;*/
    public Image healthImage;
    int Coins;
    int difficulty = 1;
    float Health;
    private void Start()
    {
        Health = 10;
        healthImage.fillAmount = (91.2f - 9.12f * Health) / 100;
    }
    private void Update()
    {
        if (Health <= 0)
        {
            GetComponent<playerController>().animDead();
            //GetComponent<PlayerHearth>().MakeDead();
            Invoke("LoadOnTime", 1);
        }
    }
    public void AddCoins() { Coins += 1; /*coinText.text = Coins.ToString();*/}
    public int GetCoins() { return Coins; }
    public void LowerHealth() { Health -= 1 * difficulty; /*lifeText.text = Health.ToString()*/; healthImage.fillAmount = (91.2f - 9.12f * Health) / 100; }
    public void AddHealth() { Debug.Log("aled"); Health += 2; /*lifeText.text = Health.ToString();*/healthImage.fillAmount = (91.2f - 9.12f * Health) / 100; }
    public float GetHealth() { return Health; }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            AddCoins();
            if (Coins == 3)
            {
                Debug.Log("GGGGG");
                //gameObject.GetComponent<PlayerHearth>().EndGame();
            }
        }
        else if (collision.tag == "Obstacle"||collision.tag=="GameCleaner")
        {
            LowerHealth();
            
        }
    }
    void LoadOnTime()
    {
        GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<ChangeLevel>().LoadScene();
    }
}
