using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    public GameObject battleUI;

    private bool inBattle;
    private GameObject player;
    private GameObject enemy;

    private Combat playerCombat;
    private Combat enemyCombat;

    void Start()
    {
        inBattle = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void EncounterEnemy(Combat _enemy)
    {
        if (_enemy && _enemy.triggerDuel)
        {
            StartBattle(_enemy);
        }
    }

    void StartBattle(Combat _enemy)
    {
        enemyCombat = _enemy;
        inBattle = true;

        // 设置目标
        player.GetComponent<Combat>().SetTarget(_enemy);
        _enemy.SetTarget(player.GetComponent<Combat>());

        // 打开战斗界面
        battleUI.SetActive(true);

    }

    void Update()
    {
        if (inBattle)
        {
            if (enemyCombat.energy >= 1)
            {
                enemyCombat.Attack();
            }

            //if (play)
        }
    }
}
