using UnityEngine;

public class Combat : MonoBehaviour
{
    [Tooltip("是否触发UI决斗")]
    public bool triggerDuel = false;

    [Header("战斗数值")]
    public int maxHealth = 1;
    public int health = 1;
    public int attack = 0;

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
        }
    }

    public void AddHealth(int _delta)
    {
        health += _delta;
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
    }

    public void BeAttacked(int _damage)
    {
        this.AddHealth(_damage * -1);
    }

    public void Attack()
    {
        if (target == null) return;
        energy = 0;
        target.BeAttacked(attack);
    }
}
