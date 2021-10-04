using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Isle : MonoBehaviour
{
    public string isleName;

    [HideInInspector]
    public int size;

    private StoryContainer storybook;

    [HideInInspector]
    public string exploreResult, exploreDesc;

    [HideInInspector]
    public int progress;

    void Start()
    {
        storybook = GetComponent<StoryContainer>();
        size = storybook.stories.Length;

        exploreResult = "progress " + progress + " result";
        exploreDesc = "progress " + (progress + 1) + " desc";
    }

    public void Explore()
    {
        if (progress >= size) return;

        Story story = storybook.GetCurrentStory();
        StoryMgr.Instance.StartStory(story, this.gameObject);
    }

    public void UpdateExplorationProgress()
    {
        progress = storybook.progress;
        IsleUI.Instance.UpdateCard(progress);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Land();
        }
    }

    // 上岛
    private void Land()
    {
        IsleUI.Instance.OpenCard(this);
    }
}
