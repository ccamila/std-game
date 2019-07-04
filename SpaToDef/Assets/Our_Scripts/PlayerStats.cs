using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;

    public static int Lifes;
    public int startLifes = 3;

    public static int Rounds;

    private void Start()
    {
        money = startMoney;
        Lifes = startLifes;
        
        Rounds = 0;
    }

 
}
