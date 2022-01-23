using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum StoryType
// {
//     Info,
//     GetFood,
//     GetWeapon,
// }

[CreateAssetMenu(fileName = "New Story", menuName = "CustomData/Story/BasicStory")]
public class Story : ScriptableObject
{
    public string storyName;
    [TextArea(1,3)]
    public string desc;
    public Sprite storyImg;
    public string interactName = "交互";

    // 故事关联性(拓展)
    // public Story nextStory;

    // [Serializable]
    // public struct itemStack
    // {
    //     public string itemName;
    //     public int itemNum;
    // }

    // 是否是一次性故事
    // public bool once;

    // 故事开销（商人故事）
    // public itemStack[] costs;

    // 故事条件1
    public CustomDataStructure.itemStack[] itemRequirements;

    // 故事奖励
    public CustomDataStructure.itemStack[] rewards;

    // 故事结果集
    public string[] results;

    // 最终结果
    [HideInInspector]
    public string result;

    public bool CheckRequirements()
    {
        for (int i = 0; i < itemRequirements.Length; i++)
        {
            if (Inventory.HasStack(itemRequirements[i]) == false)
                return false;
        }
        return true;
    }

    // 故事准备
    public virtual void Prepare()
    {

    }

    // 故事运行
    // 返回值为故事是否完结（可删除）
    public virtual bool Run()
    {
        if (!CheckRequirements()) 
        {
            NoticeMgr.Instance.ShowMessage("不满足条件！");
            return false;
        }

        foreach (CustomDataStructure.itemStack stack in itemRequirements)
            Inventory.DelItemStack(stack);

        foreach (CustomDataStructure.itemStack stack in rewards)
            Inventory.AddItemStack(stack);

        result = results[UnityEngine.Random.Range(0, results.Length)];
        return true;
    }

    public virtual bool Leave()
    {
        return true;
    }
}
