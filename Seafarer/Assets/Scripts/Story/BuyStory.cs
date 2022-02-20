using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story", menuName = "CustomData/Story/BuyStory")]
public class BuyStory : Story
{
    public Item item;

    public override void Prepare()
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
            CustomDataStructure.itemStack stack = new CustomDataStructure.itemStack();
            stack.itemName = item.itemName;
            stack.itemNum = 1;
            Inventory.AddItemStack(stack);
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
