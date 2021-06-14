using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameStates
    {
        Menu,
        InGame,
        GameOver
    }
public class GameManager : MonoBehaviour
{
   public GameStates currentGameState=GameStates.Menu;
    private static GameManager sharedInstance;
    public Canvas mainMenu;
    public Canvas gameMenu;
    public Canvas gameOverMenu;
    private int collectedCoins=0;
    public void Start()
    {
        currentGameState=GameStates.Menu;
    }
    public void Update()
    {
        if(Input.GetButtonDown("S")&&currentGameState!=GameStates.InGame)
        {
            ChangeGameState(GameStates.InGame);
            StartGame();
        }
    }
    private void Awake()
    {
        gameMenu.enabled=false;
        gameOverMenu.enabled=false;
        mainMenu.enabled=true;
        sharedInstance=this;
    }
    public static GameManager GetInstance()
    {
        return sharedInstance;
    }
   public void StartGame()
    {
        gameMenu.enabled=false;
        mainMenu.enabled=true;
        gameOverMenu.enabled=false;
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        LevelGenerator.sharedInstance.CreateInitialBlocks();
        playerController.GetInstance().StartGame();
        ChangeGameState(GameStates.InGame);
        collectedCoins=0;
    }

    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeGameState(GameStates.GameOver);
    }
    public void BackToMainMenu()
    {
        playerController.GetInstance().animator.SetBool("isAlive",true);
        ChangeGameState(GameStates.Menu);
    }
    void ChangeGameState(GameStates newGameState)
    {
        if(newGameState==GameStates.Menu)
        {
            
            gameMenu.enabled=false;
            mainMenu.enabled=true;
        gameOverMenu.enabled=false;
            
        }
        else if(newGameState==GameStates.InGame)
        {
            mainMenu.enabled=false;
            
            gameMenu.enabled=true;
        gameOverMenu.enabled=false;
        }
        else if(newGameState==GameStates.GameOver)
        {
            mainMenu.enabled=false;
            
            gameMenu.enabled=false;
            gameOverMenu.enabled=true;
        
        }
        currentGameState=newGameState;
    }
    public void CollectCoins()
    {
        collectedCoins+=1;
    }
    public int GetCollectedCoins()
    {
        return collectedCoins;
    }
}
