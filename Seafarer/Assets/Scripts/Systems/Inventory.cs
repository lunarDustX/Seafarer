using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static int coins = 10;
    public delegate void OnCoinChanged(int coin);
    public static OnCoinChanged onCoinChanged;

    public static Action onInventoryChanged;

    public struct ItemStack 
    {
        public string itemName;
        public int itemNum;
    };

    public static List<ItemStack> stacks = new List<ItemStack>();

    public static void AddCoins(int _delta)
    {
        coins += _delta;
        // coins = Mathf.Max(coins, 0);

        if (onCoinChanged != null)
            onCoinChanged(coins);
    }

    public static void AddItem(string _itemName, int _itemNum) 
    {
        if (_itemNum == 0) return;

        bool stackFound = false;
        for (int i = 0; i < stacks.Count; i++)
        {
            ItemStack stack = stacks[i];
            if (stack.itemName == _itemName) 
            {
                stack.itemNum += _itemNum;
                stacks[i] = stack;//+= _itemNum;
                stackFound = true;
                break;
            }
        }
        if (stackFound == false) 
        {
            ItemStack s;
            s.itemName = _itemName;
            s.itemNum = _itemNum;
            stacks.Add(s);
        }

        if (onInventoryChanged != null)
            onInventoryChanged.Invoke();
    }




}
