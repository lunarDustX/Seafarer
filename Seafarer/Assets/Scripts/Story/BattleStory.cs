using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BattleStory", menuName = "CustomData/Story/BattleStory")]
public class BattleStory : Story
{
    [Tooltip("海盗的财富")]
    public int coins;
    public int health;
    public int attack;

    [Tooltip("逃跑的代价")]
    public int leavePrice;

    // 故事的初始化
    public override void Prepare()
    {
        desc = "攻击：" + attack + " 血量：" + health;
    }

    // 进行故事交互
    public override bool Run()
    {
        Player player = FindObjectOfType<Player>();
        if (player.health * player.attack >= attack * health) 
        {
            result = "win";
            return true;
        }
        else 
        {
            result = "lose";
            return false;
        }
    }

    // 逃跑
    public override bool Leave()
    {
        Debug.Log("逃离战斗");
        Inventory.AddCoins(-leavePrice);
        return true;
    }
}
