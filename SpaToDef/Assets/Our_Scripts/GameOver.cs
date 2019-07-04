using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour{
    public Text roundsText;


    //public SceneFader sceneFader;


    void OnEnable(){
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public  void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Função GameOver: Retry.");
    }
    
    public void Menu()
    {
        Debug.Log("Função GameOver: Menu.");
    }


}
