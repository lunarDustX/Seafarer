using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private StoryContainer storybook;

    void Start()
    {
        storybook = GetComponent<StoryContainer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Story bubbleStory = storybook.GetCurrentStory();
            StoryMgr.Instance.ShowStory(bubbleStory, this.gameObject);
        }
    }

    public void BubbleDisappear()
    {
        Destroy(this.gameObject);
    }
}
