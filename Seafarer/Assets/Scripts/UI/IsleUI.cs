using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsleUI : MonoBehaviour
{
    public static IsleUI Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);
    }

    public GameObject isleCard;
    public Button exploreBtn;
    public Button leaveBtn;

    public Text nameTxt;
    public Text progressTxt;
    public Text resultTxt;
    public Text descTxt;

    private Isle currentIsle;

    void Start()
    {
        exploreBtn.onClick.AddListener(ExploreBtnClicked);
        leaveBtn.onClick.AddListener(LeaveBtnClicked);
    }

    // Open Story Book
    void ExploreBtnClicked()
    {
        currentIsle.Explore();
    }

    // Close Story Book
    void LeaveBtnClicked()
    {
        CloseCard();
    }

    public void OpenCard(Isle _isle)
    {
        currentIsle = _isle;
        // init data
        UpdateCard(_isle.progress);
        
        isleCard.SetActive(true);
    }

    public void CloseCard()
    {
        isleCard.SetActive(false);
    }

    public void UpdateCard(int _progress)
    {
        nameTxt.text = currentIsle.isleName;
        progressTxt.text = "探索进度 " + _progress + " / " + currentIsle.size;

        /*
        resultTxt.text = currentIsle.exploreResult;
        descTxt.text = currentIsle.exploreDesc;

        if (_progress >= currentIsle.size)
            exploreBtn.gameObject.SetActive(false);
        */
    }
}
