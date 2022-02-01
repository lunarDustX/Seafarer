using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    #region Singleton
    public static BattleMgr Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [Header("UI引用")]
    public GameObject battleUI;

    [HideInInspector]
    public bool inBattle;
    private GameObject player;
    private GameObject enemy;

    private Combat playerCombat;
    private Combat enemyCombat;

    void Start()
    {
        inBattle = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerCombat = player.GetComponent<Combat>();
    }

    // 遇到敌人
    // 勾选配置才出发决斗
    public void EncounterEnemy(Combat _enemyCombat)
    {
        if (_enemyCombat && _enemyCombat.triggerDuel)
        {
            StartBattle(_enemyCombat);
        }
    }

    // 开始决斗
    void StartBattle(Combat _enemyCombat)
    {
        enemyCombat = _enemyCombat;
        inBattle = true;

        // 设置攻击目标
        player.GetComponent<Combat>().SetTarget(_enemyCombat);
        _enemyCombat.SetTarget(player.GetComponent<Combat>());

        // 打开战斗界面
        battleUI.SetActive(true);
        battleUI.GetComponent<BattleUI>().Init(playerCombat, _enemyCombat);
    }

    void EndBattle()
    {
        inBattle = false;

        // 关闭战斗界面
        battleUI.SetActive(false);
    }

    // 玩家发起攻击
    public void PlayerAttack()
    {
        playerCombat.Attack();
    }

    void Update()
    {
        if (inBattle)
        {
            if (enemyCombat.energy >= 1)
            {
                enemyCombat.Attack();
                if (playerCombat.health <= 0)
                {
                    
                }
            }

            // 退出条件
            if (playerCombat == null || enemyCombat == null)
            {
                EndBattle();
            }
        }
    }
}
