using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotNew : MonoBehaviour
{
    public Text itemName;
    public Text itemNum;
    public Image itemProfile;


    void Start()
    {
        itemNum.text = "";
        itemProfile.sprite = null;
    }

    public void ShowStack(CustomDataStructure.itemStack _stack)
    {
        //itemName.text = _stack.itemName;
        itemProfile.sprite = _stack.item.img;
        itemNum.text = _stack.itemNum.ToString();
    }

    public void Empty() 
    {
        //itemName.text = "";
        itemNum.text = "";
    }
}
