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

    public Image playerProfile, enemyProfile;

    private float playerFlashTimer, enemyFlashTimer;

    public Button attackBtn;

    private Combat enemyCombat;
    private Combat playerCombat;

    private int playerPreHealth, enemyPreHealth;

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

        playerPreHealth = playerCombat.health;
        enemyPreHealth = enemyCombat.health;

        playerProfile.material.SetInt("_Flash", 0);
        enemyProfile.material.SetInt("_Flash", 0);

    }

    void AttackBtnClicked()
    {
        BattleMgr.Instance.PlayerAttack();
    }

    // 更新双方战斗状态
    void UpdateBattleState()
    {
        #region 受击表现
        if (playerPreHealth != playerCombat.health)
        {
            playerPreHealth = playerCombat.health;
            playerProfile.material.SetInt("_Flash", 1);
            playerFlashTimer = 0.5f;
        }

        if (playerFlashTimer > 0) 
        {
            playerFlashTimer -= Time.deltaTime;
            if (playerFlashTimer <= 0)
                playerProfile.material.SetInt("_Flash", 0);
        }

        if (enemyPreHealth != enemyCombat.health)
        {
            enemyPreHealth = enemyCombat.health;
            enemyProfile.material.SetInt("_Flash", 1);
            enemyFlashTimer = 0.5f;
        }

        if (enemyFlashTimer > 0) 
        {
            enemyFlashTimer -= Time.deltaTime;
            if (enemyFlashTimer <= 0)
                enemyProfile.material.SetInt("_Flash", 0);
        }
        #endregion

        playerHealth.text = playerCombat.health + "/" + playerCombat.maxHealth;
        enemyHealth.text = enemyCombat.health + "/" + enemyCombat.maxHealth;

        playerEnergyFill.fillAmount = playerCombat.energy;
        enemyEnergyFill.fillAmount = enemyCombat.energy;
    }


}
