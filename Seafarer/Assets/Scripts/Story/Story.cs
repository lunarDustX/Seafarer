using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// public enum StoryType
// {
//     Info,
//     GetFood,
//     GetWeapon,
// }

[CreateAssetMenu(fileName = "New Story", menuName = "Story/BasicStory")]
public class Story : ScriptableObject
{
    public string storyName;
    [TextArea(1,3)]
    public string desc;
    public Sprite storyImg;
    public string interactName = "Explore";
    //public StoryType storyType;
    //public int num;

    [Serializable]
    public struct itemStack
    {
        public string itemName;
        public int itemNum;
    }

    // Item 奖励
    public itemStack[] rewards;

    // 故事结果集
    public string[] results;

    // 最终结果
    [HideInInspector]
    public string result;

    // 故事运行
    public virtual bool Run()
    {
        foreach (itemStack stack in rewards)
            Inventory.AddItem(stack.itemName, stack.itemNum);

        result = results[UnityEngine.Random.Range(0, results.Length)];
        return true;
    }
}
