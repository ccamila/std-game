﻿using System.Collections;
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

    public void menu(){

        SceneManager.LoadScene("Menu");

    }

    public void level_1(){

        SceneManager.LoadScene("Cena_teste");

    }

}
