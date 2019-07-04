using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject generalUI;
    public void Toggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        generalUI.SetActive(!generalUI.activeSelf);
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
