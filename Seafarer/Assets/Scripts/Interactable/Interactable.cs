using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteracted;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnInteracted != null)
                OnInteracted.Invoke();
        }
    }

    public void AddItem(ItemStackData _itemStack)
    {
        int types = _itemStack.itemNames.Length;
        for (int i = 0; i < types; i++)
        {
            string itemName = _itemStack.itemNames[i];
            int itemNum = _itemStack.itemNums[i];
            Inventory.AddItem(itemName, itemNum);
        }
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
