using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    #region Singleton
    public static UIMgr Instance;
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

    [Header("Basic UI")]
    public Text foodTxt;
    public Text locationTxt;
    public Text coinTxt;

    [Header("Story UI")]
    public Image storyCard;
    public Image resultCard;

    public Text storyName;
    public Text storyDesc;
    public Button exploreBtn;
    public Button leaveBtn;

    public Text resultDesc;
    public Button continueBtn;

    public Text interactBtn;

    void Start()
    {
        PlayerController.onFoodChanged += UpdateFood;
        PlayerController.onMoved += UpdatePlayerLocation;

        Inventory.onCoinChanged += UpdateCoins;

        // MARKER STORY CARD 
        StoryMgr.Instance.onStoryStarted += ShowStoryCard;
        StoryMgr.Instance.onStoryEnded += CloseStoryCard;
        StoryMgr.Instance.onStoryQuitted += CloseStoryCard;
        StoryMgr.Instance.onStoryRun += DisplayStoryResult;

        storyCard.gameObject.SetActive(false);
        resultCard.gameObject.SetActive(false);

        leaveBtn.onClick.AddListener(LeaveBtnClicked);
        exploreBtn.onClick.AddListener(ExploreBtnClicked);
        continueBtn.onClick.AddListener(ContinueBtnClicked);
    }

    #region StoryCard
    private void LeaveBtnClicked()
    {
        StoryMgr.Instance.QuitStory();
    }

    private void ExploreBtnClicked()
    {
        StoryMgr.Instance.RunCurrentStory();
    }

    private void ContinueBtnClicked()
    {
        StoryMgr.Instance.EndCurrentStory();
    }

    void ShowStoryCard(Story _story)
    {
        //print(_story.desc);
        storyName.text = _story.storyName;
        storyDesc.text = _story.desc;
        interactBtn.text = _story.interactName;
        storyCard.gameObject.SetActive(true);
    }

    void CloseStoryCard()
    {
        // 结果展示卡片是否和故事卡片合并？
        resultCard.gameObject.SetActive(false);
        storyCard.gameObject.SetActive(false);
    }

    void DisplayStoryResult(Story _story)
    {
        resultDesc.text = _story.result;
        resultCard.gameObject.SetActive(true);
    }
    #endregion

    #region Main UI
    void UpdateFood(int _food, int _deltaFood)
    {
        foodTxt.text = _food.ToString();
    }

    void UpdatePlayerLocation(int _x, int _y)
    {
        locationTxt.text = "( " + _x + " , " + _y +" )";
    }

    void UpdateCoins(int _coins)
    {
        coinTxt.text = _coins.ToString();
    }
    #endregion

}
