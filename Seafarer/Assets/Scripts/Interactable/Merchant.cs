using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoryContainer))]
[RequireComponent(typeof(Collider2D))]
public class Merchant : MonoBehaviour
{
    // 考虑实现修改故事书
    private StoryContainer storybook;

    void Start()
    {
        storybook = GetComponent<StoryContainer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Story story = storybook.GetCurrentStory();
            StoryMgr.Instance.StartStory(story, this.gameObject);
        }
    }
}
