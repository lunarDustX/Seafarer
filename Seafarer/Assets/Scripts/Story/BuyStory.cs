using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story", menuName = "Story/BuyStory")]
public class BuyStory : Story
{
    public Item item;
    
    void Start() 
    {
        Debug.Log("Start of BuyStory.");
        storyName = item.itemName;
        desc = item.desc;
        storyImg = item.img;
    }

    public override bool Run()
    {
        int price = item.price;
        if (Inventory.coins >= price)
        {
            Inventory.AddCoins(-price);
            Inventory.AddItem(item.itemName, 1);
            result = "购买成功！";
            return true;
        } 
        else 
        {
            result = "金币不足！";
            return false;
        }
    }
}
