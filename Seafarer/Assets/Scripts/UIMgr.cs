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
    public GameObject itemSlotPrefab;
    public GameObject slotPanel;
    public GameObject inventoryPanel;

    [Header("Story UI")]
    public Image storyCard;
    public Image resultCard;

    public Text storyName;
    public Text storyDesc;
    public Image storyImg;
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
        Inventory.onInventoryChanged += UpdateInventory;

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

    // 弹出故事卡
    void ShowStoryCard(Story _story)
    {
        // 初始化卡片信息
        if (_story.storyImg == null)
            Debug.LogWarning("当前故事卡没有设置图片");

        storyImg.sprite = _story.storyImg;
        storyName.text = _story.storyName;
        storyDesc.text = _story.desc;
        interactBtn.text = _story.interactName;

        resultCard.gameObject.SetActive(false);
        // TODO 弹出动效
        storyCard.gameObject.SetActive(true);
    }

    void CloseStoryCard()
    {
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

    void UpdateInventory() 
    {
        List<Inventory.ItemStack> stacks = Inventory.stacks;
        ItemSlot[] slots = slotPanel.GetComponentsInChildren<ItemSlot>();
        for (int i = 0; i < slots.Length; i++) 
        {
            if (i < stacks.Count)
                slots[i].ShowStack(stacks[i]);
            else
                slots[i].Empty();
        }

        if (stacks.Count > slots.Length)
        {
            Debug.Log("Not Enough Slot.");
        }
    }
    #endregion

    void Update() 
    {
        // 打开背包
        if (Input.GetKeyDown(KeyCode.I))
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
