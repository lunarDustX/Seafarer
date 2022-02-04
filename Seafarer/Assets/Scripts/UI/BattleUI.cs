using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public Image playerEnergyFill;
    public Image enemyEnergyFill;

    public Text playerHealth;
    public Text enemyHealth;

    public Button attackBtn;

    private Combat enemyCombat;
    private Combat playerCombat;

    void Start()
    {
        attackBtn.onClick.AddListener(AttackBtnClicked);
    }

    void Update()
    {
        if (BattleMgr.Instance.inBattle == false) return;
        UpdateBattleState();
    }

    // 初始化
    public void Init(Combat _playerCombat, Combat _enemyCombat)
    {
        playerCombat = _playerCombat;
        enemyCombat = _enemyCombat;
    }

    void AttackBtnClicked()
    {
        BattleMgr.Instance.PlayerAttack();
    }

    // 更新双方战斗状态
    void UpdateBattleState()
    {
        playerHealth.text = playerCombat.health + "/" + playerCombat.maxHealth;
        enemyHealth.text = enemyCombat.health + "/" + enemyCombat.maxHealth;

        playerEnergyFill.fillAmount = playerCombat.energy;
        enemyEnergyFill.fillAmount = enemyCombat.energy;
    }


}
