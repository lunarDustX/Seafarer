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

    public void Interact()
    {
        if (OnInteracted != null)
            OnInteracted.Invoke();
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         if (OnInteracted != null)
    //             OnInteracted.Invoke();
    //     }
    // }

    public void AddItem(ItemStackData _data)
    {
        int types = _data.stacks.Length;
        for (int i = 0; i < types; i++)
        {
            CustomDataStructure.itemStack stack = _data.stacks[i];
            Inventory.AddItemStack(stack);
        }
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
