using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    Image buttonImage;
    private Color startColor = Color.white;
    public GameObject selectedButton;
    
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void DefaultColor()
    {
        selectedButton.GetComponent<Image>().color = startColor;
        selectedButton = null;
    }

    public void SelectedColor(GameObject button)
    {
        if(selectedButton != null)
        {
            DefaultColor();
        }
        selectedButton = button;
        button.GetComponent<Image>().color = Color.black;
    }
}
