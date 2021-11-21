using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/BasicItem")]
public class Item : ScriptableObject
{
    public string itemName;
    public string desc;
    public Sprite img;
    public int price;
}
