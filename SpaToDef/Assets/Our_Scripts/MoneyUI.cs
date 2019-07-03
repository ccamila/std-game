using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public Text moneyText;
    

    // Tirar do update e ser alterado quando for acionado
    void Update(){
        moneyText.text = "$ " + PlayerStats.money.ToString();
    }
}
