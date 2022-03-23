using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHearth : MonoBehaviour
{
    public CanvasGroup endCG;
    public Text endGameUIText;
    public string endText="You Win!";
    public string endTextLoose = "You died;";
    public void EndGame()
    {
        endGameUIText.text = endText;
        endCG.alpha = 1;
    }
    public void MakeDead()
    {
        endText = endTextLoose;
        //Invoke("EndGame",3);
    }

}
