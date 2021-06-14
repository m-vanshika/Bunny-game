using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViewInGame : MonoBehaviour
{
    public Text coinsLabel;
    public Text scoreText;
    public Text maxScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().currentGameState==GameStates.Menu)
        {
            maxScore.text=playerController.GetInstance().GetMaxScore().ToString();
    
        }
        if (GameManager.GetInstance().currentGameState==GameStates.InGame)
        {
           coinsLabel.text=GameManager.GetInstance().GetCollectedCoins().ToString();
       scoreText.text= playerController.GetInstance().GetDistance().ToString();
         
        }
        }
}
