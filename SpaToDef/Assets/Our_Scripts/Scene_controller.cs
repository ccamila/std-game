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

    static public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level_1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevel()
    {

    }

    public void Options()
    {

    }
}
