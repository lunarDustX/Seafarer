using UnityEngine;

// Storybook Reader
public class StoryMgr : MonoBehaviour
{
    #region Singleton
    public static StoryMgr Instance;
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

    public delegate void OnStoryStarted(Story story);
    public OnStoryStarted onStoryStarted;

    public delegate void OnStoryEnded();
    public OnStoryEnded onStoryEnded;

    public delegate void OnStoryRun(Story story);
    public OnStoryRun onStoryRun;

    public delegate void OnStoryQuitted();
    public OnStoryQuitted onStoryLeft;

    private Story currentStory;
    private bool currentStoryEnd;
    private GameObject storyPlace;

    // 展示故事
    public void ShowStory(Story _story, GameObject _place)
    {
        if (_story == null)
        {
            Debug.Log("there is no story?");
            return;
        }

        currentStory = _story;
        storyPlace = _place;

        PlayerController.inControl = false;

        _story.Prepare();
        if (onStoryStarted != null)
            onStoryStarted.Invoke(_story);
    }

    // 进入故事
    public void RunCurrentStory()
    {
        currentStoryEnd = currentStory.Run();

        if (onStoryRun != null)
            onStoryRun.Invoke(currentStory);
    }

    // 不进入故事交互
    public void LeaveStory()
    {
        currentStory.Leave();

        if (onStoryLeft != null)
            onStoryLeft.Invoke();

        ClearStory();
        PlayerController.inControl = true;
    }

    // 尝试完成故事
    public void TryFinishCurrentStory()
    {
        // if (onStoryEnded != null)
        //     onStoryEnded.Invoke();
        if (onStoryLeft != null)
            onStoryLeft.Invoke();

        if (currentStoryEnd == true && storyPlace)
        {
            StoryContainer storybook = storyPlace.GetComponent<StoryContainer>();
            if (storybook)
                storybook.OneStoryEnd();
        }

        ClearStory();
        PlayerController.inControl = true;
    }

    private void ClearStory(Story _story = null, GameObject _place = null)
    {
        currentStory = null;
        storyPlace = null;
    }
}
