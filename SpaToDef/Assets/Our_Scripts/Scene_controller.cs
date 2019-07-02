using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Level_1()
    {
        Time.timeScale = 3f;
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevel()
    {

    }

    public void Options()
    {

    }
}
