using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int coins;

    public delegate void OnCoinChanged(int coin);
    public static OnCoinChanged onCoinChanged;

    public static void AddCoins(int _delta)
    {
        coins += _delta;
        coins = Mathf.Max(coins, 0);

        if (onCoinChanged != null)
            onCoinChanged(coins);
    }

}
