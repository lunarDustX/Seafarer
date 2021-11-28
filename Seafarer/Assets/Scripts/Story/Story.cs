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
    public string interactName = "交互";

    // 故事关联性(拓展)
    // public Story nextStory;

    [Serializable]
    public struct itemStack
    {
        public string itemName;
        public int itemNum;
    }

    // 是否是一次性故事
    // public bool once;

    // 故事参与条件（比如等级要求）
    // requirements

    // 故事开销（商人故事）
    // public itemStack[] costs;

    // 故事奖励
    public itemStack[] rewards;

    // 故事结果集
    public string[] results;

    // 最终结果
    [HideInInspector]
    public string result;


    // 故事准备
    public virtual void Prepare()
    {

    }

    // 故事运行
    // 返回值为故事是否完结（可删除）
    public virtual bool Run()
    {
        foreach (itemStack stack in rewards)
            Inventory.AddItem(stack.itemName, stack.itemNum);

        result = results[UnityEngine.Random.Range(0, results.Length)];
        return true;
    }

    public virtual bool Leave()
    {
        return true;
    }
}
