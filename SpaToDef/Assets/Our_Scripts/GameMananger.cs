using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    public static bool gameEnded = false;
    public GameObject gameOverUI;
    void Update()
    {
        if (gameEnded)
            return;
        if (PlayerStats.Lifes <= 0) EndGame();
   
    }

    void EndGame()
    {
        gameEnded = true;
        
        gameOverUI.SetActive(true);

             
    }
}
