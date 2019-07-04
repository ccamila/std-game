using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    void Start()
    {
        gameEnded = false;
    }



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

    public void WinLevel()
    {
        gameEnded = true;
        gameWonUI.SetActive(true);
    }
}
