using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomDataStructure : MonoBehaviour
{
    [Serializable]
    public struct itemStack
    {
        public Item item;
        public string itemName; // delete Later
        public int itemNum;
    }
}


