using UnityEngine;

public class Combat : MonoBehaviour
{
    [Tooltip("是否触发UI决斗")]
    public bool triggerDuel = false;
    public bool autoAttack = true;

    [Header("战斗数值")]
    public int maxHealth = 1;
    public int health = 1;
    [Tooltip("攻击力")]
    public int attack = 0;
    [Tooltip("闪避率")]
    public float evasionRate = 0.05f;
    public float criticalRate = 0.05f;

    [HideInInspector]
    public float energy = 0;
    public float energyRecoverSpd = 0.4f;

    private Combat target;

    void Start()
    {
        target = null;
    }

    void Update()
    {
        if (energy < 1)
        {
            energy += energyRecoverSpd * Time.deltaTime;
            if (autoAttack && energy >= 1)
            {
                Attack();
            }
        }
    }

    public void AddHealth(int _delta)
    {
        health += _delta;
        health = Mathf.Clamp(health, 0, maxHealth);
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void SetTarget(Combat _target)
    {
        target = _target;

        // 重置攻击能量
        energy = 0;
    }

    public void BeAttacked(int _damage)
    {
        Debug.Log(transform.name + " be attacked.");
        // 闪避判定可能要换个位置
        bool evade = Random.Range(0f, 1f) < evasionRate;
        if (evade == false)
        {
            this.AddHealth(_damage * -1);
            //if
        }
    }

    public void Attack()
    {
        if (target == null) return;
        energy = 0;

        bool crit = Random.Range(0f, 1f) < criticalRate;
        int damage = crit ? attack * 2 : attack;

        target.BeAttacked(damage);
    }
}
