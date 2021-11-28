using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateUI : MonoBehaviour
{
    public static PirateUI Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject battleCard;
    public GameObject battleResultCard;

    public Button battleBtn;
    public Button fleeBtn;
    public Button continueBtn;

    public Text resultTxt;
    public Text attackTxt;
    public Text coinTxt;
    public Text foodTxt;
    public Text winChanceTxt;

    private Pirate currentPirate;

    private void Start()
    {
        battleBtn.onClick.AddListener(BattleBtnClicked);
        fleeBtn.onClick.AddListener(CloseBattleUI);
        continueBtn.onClick.AddListener(CloseBattleUI);
    }

    void BattleBtnClicked()
    {
        currentPirate.Battle();
    }

    public void OpenBattleUI(Pirate _pirate)
    {
        currentPirate = _pirate;

        attackTxt.text = _pirate.attack.ToString();
        coinTxt.text = _pirate.coins.ToString();
        foodTxt.text = _pirate.food.ToString();
        winChanceTxt.text = "获胜概率" + Mathf.RoundToInt(_pirate.winChance * 100) + "%";

        battleCard.SetActive(true);
    }

    public void ShowBattleResult(bool _playerWin)
    {
        if (_playerWin)
            resultTxt.text = "你赢了！";
        else
            resultTxt.text = "你输了！";

        battleCard.SetActive(false);
        battleResultCard.SetActive(true);
    }

    public void CloseBattleUI()
    {
        battleCard.SetActive(false);
        battleResultCard.SetActive(false);
    }
}
