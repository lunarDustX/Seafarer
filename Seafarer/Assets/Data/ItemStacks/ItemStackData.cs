using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStack", menuName = "CustomData/ItemStack")]
public class ItemStackData : ScriptableObject
{
    public CustomDataStructure.itemStack[] stacks;
}
