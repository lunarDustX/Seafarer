using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// think of this as a storybook
public class StoryContainer : MonoBehaviour
{
    public Story[] stories;

    public UnityEvent onOneStoryEnd;
    public UnityEvent onAllStoryEnd;

    // think of this as a bookmark
    [HideInInspector]
    public int progress;

    public Story GetCurrentStory()
    {
        if (progress >= stories.Length)
        {
            Debug.LogError("Storybook Range");
            return null;
        }

        return stories[progress];
    }

    // 触发故事
    public void TriggerStory()
    {
        //StoryContainer storybook = GetComponent<StoryContainer>();
        Story story = this.GetCurrentStory();
        StoryMgr.Instance.ShowStory(story, this.gameObject);
    }

    public void OneStoryEnd()
    {
        progress++;
        Debug.Log("bookPage: " + progress);

        if (onOneStoryEnd != null)
            onOneStoryEnd.Invoke();

        if (progress >= stories.Length)
            AllStoryEnd();
    }

    public void AllStoryEnd()
    {
        if (onAllStoryEnd != null)
            onAllStoryEnd.Invoke();
    }
}
