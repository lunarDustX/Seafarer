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

    public static List<CustomDataStructure.itemStack> stacks = new List<CustomDataStructure.itemStack>();

    public static void AddCoins(int _delta)
    {
        coins += _delta;
        // coins = Mathf.Max(coins, 0);

        if (onCoinChanged != null)
            onCoinChanged(coins);
    }

    // 检查是否有物品
    public static bool HasStack(CustomDataStructure.itemStack _stack)
    {
        for (int i = 0; i < stacks.Count; i++)
        {
            CustomDataStructure.itemStack stack = stacks[i];
            if (stack.itemName == _stack.itemName) 
            {
                if (stack.itemNum >= _stack.itemNum) 
                    return true;
            }
        }
        return false;
    }

    // 消耗物品
    public static void DelItemStack(CustomDataStructure.itemStack _stack)
    {
        if (_stack.itemNum == 0) return;

        for (int i = 0; i < stacks.Count; i++)
        {
            CustomDataStructure.itemStack stack = stacks[i];
            if (stack.itemName == _stack.itemName) 
            {
                stack.itemNum -= _stack.itemNum;
                NoticeMgr.Instance.ShowMessage(_stack.itemName + "+"+_stack.itemNum);
                break;
            }
        }

        if (onInventoryChanged != null)
            onInventoryChanged.Invoke();
    }

    // 获得物品
    public static void AddItemStack(CustomDataStructure.itemStack _stack) 
    {
        if (_stack.itemNum == 0) return;

        bool stackFound = false;
        for (int i = 0; i < stacks.Count; i++)
        {
            CustomDataStructure.itemStack stack = stacks[i];
            if (stack.itemName == _stack.itemName) 
            {
                stack.itemNum += _stack.itemNum;
                stacks[i] = stack;//+= _itemNum;
                stackFound = true;
                break;
            }
        }
        if (stackFound == false) 
        {
            stacks.Add(_stack);
        }

        NoticeMgr.Instance.ShowMessage(_stack.itemName + "+"+_stack.itemNum);

        if (onInventoryChanged != null)
            onInventoryChanged.Invoke();
    }




}
