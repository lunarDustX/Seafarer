using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PirateTeam
{
    WHITE, 
    RED,
    BLUE,
    YELLOW,
}

[RequireComponent(typeof(Collider2D))]
public class Pirate : MonoBehaviour
{
    public int attack;
    public PirateTeam team;
    public int coins;
    public int food;

    //public UnityEvent onBattleStarted;
    [HideInInspector]
    public float winChance;

    private StoryContainer storybook;

    void Start()
    {
        storybook = GetComponent<StoryContainer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Encounter();
            Story story = storybook.GetCurrentStory();
            StoryMgr.Instance.ShowStory(story, this.gameObject);
        }
    }

    private void CalculateWinChance()
    {
        int playerAttack = FindObjectOfType<Player>().attack;
        if (playerAttack >= attack)
            winChance = 1f;
        else
            winChance = 1 / (attack - playerAttack) * 0.5f;
    }

    private void Encounter()
    {
        CalculateWinChance();
        PirateUI.Instance.OpenBattleUI(this);
        //if (onBattleStarted != null)
        //    onBattleStarted.Invoke();
    }

    public void Battle()
    {
        bool playerWin = Random.Range(0f, 1f) < winChance;
        BattleEnd(playerWin);
    }

    private void BattleEnd(bool _playerWin)
    {
        PirateUI.Instance.ShowBattleResult(_playerWin);

        if (_playerWin)
        {
            Die();
        }
        else
        {
                
        }
    }

    private void Die()
    {
        GiveLoots();
        Destroy(this.gameObject);
    }

    private void GiveLoots()
    {
        Inventory.AddCoins(coins);
    }
}
