using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Text itemName;
    public Text itemNum;
    public void ShowStack(CustomDataStructure.itemStack _stack)
    {
        itemName.text = _stack.itemName;
        itemNum.text = _stack.itemNum.ToString();
    }

    public void Empty() 
    {
        itemName.text = "";
        itemNum.text = "";
    }
}
