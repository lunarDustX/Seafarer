using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryType
{
    Info,
    GetFood,
    GetWeapon,
}

[CreateAssetMenu(fileName = "New Story", menuName = "Story/CommonStory")]
public class Story : ScriptableObject
{
    public string storyName;
    [TextArea(1,3)]
    public string desc;
    public Sprite img;
    public string interactName = "Explore";
    //public StoryType storyType;
    //public int num;

    [HideInInspector]
    public int reward;

    public string[] results;

    [HideInInspector]
    public string result;

    public virtual bool Run()
    {
        result = results[Random.Range(0, results.Length)];
        return true;
    }
}
