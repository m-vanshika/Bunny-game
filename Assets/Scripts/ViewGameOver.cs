using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour
{
    public Text coinsLabel;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().currentGameState==GameStates.GameOver)
        {
            coinsLabel.text=GameManager.GetInstance().GetCollectedCoins().ToString();
       scoreText.text= playerController.GetInstance().GetDistance().ToString();
    
        }
        
    }
}
