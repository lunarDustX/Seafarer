using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomDataStructure : MonoBehaviour
{
    [Serializable]
    public struct itemStack
    {
        public string itemName;
        public int itemNum;
    }
}


