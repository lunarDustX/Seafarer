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
            Debug.LogError("Storybook Range");

        return stories[progress];
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
