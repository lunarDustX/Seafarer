using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public OnStoryQuitted onStoryQuitted;

    private Story currentStory;
    private GameObject storyPlace;

    public void StartStory(Story _story, GameObject _place)
    {
        if (_story == null)
        {
            Debug.Log("there is no story?");
            return;
        }

        currentStory = _story;
        storyPlace = _place;

        PlayerController.inControl = false;

        if (onStoryStarted != null)
            onStoryStarted.Invoke(_story);
    }

    public void RunCurrentStory()
    {
        currentStory.Run();

        if (onStoryRun != null)
            onStoryRun.Invoke(currentStory);
    }

    public void QuitStory()
    {
        if (onStoryQuitted != null)
            onStoryQuitted.Invoke();

        ClearStory();
        PlayerController.inControl = true;
    }

    public void EndCurrentStory()
    {
        if (onStoryEnded != null)
            onStoryEnded.Invoke();

        if (storyPlace)
        {
            StoryContainer c = storyPlace.GetComponent<StoryContainer>();
            if (c)
                c.OneStoryEnd();
        }
        //if (storyPlace) Destroy(storyPlace);

        ClearStory();
        PlayerController.inControl = true;
    }

    private void ClearStory(Story _story = null, GameObject _place = null)
    {
        currentStory = null;
        storyPlace = null;
    }
}
