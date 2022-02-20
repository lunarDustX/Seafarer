using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteracted;

    public void Interact()
    {
        if (OnInteracted != null)
            OnInteracted.Invoke();
    }

    // 掉落物品 Loot
    public void AddItem(ItemStackData _data)
    {
        int types = _data.stacks.Length;
        for (int i = 0; i < types; i++)
        {
            CustomDataStructure.itemStack stack = _data.stacks[i];
            Inventory.AddItemStack(stack);
        }
    }

    // 说话
    public void SaySomething(string _content)
    {
        NoticeMgr.Instance.CreateWorldReminder(this.transform.position, _content);
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
