using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPanel;
    public Text itemDescription;

    private int slotPointer;
    private int slotNum;

    private ItemSlotNew[] slots;

    void Start()
    {
        Inventory.onInventoryChanged += UpdateInventory;

        slots = slotPanel.GetComponentsInChildren<ItemSlotNew>();
        slotNum = slots.Length;

        UpdateInventory();
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        bool f = false;

        if (Input.GetKeyDown(KeyCode.A))
        {
            slotPointer -= 1;
            f = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            slotPointer += 1;
            f = true;
        }

        if (!f) return;

        int N = Inventory.stacks.Count;
        if (N > 0)
        {
            slotPointer = (slotPointer + N) % N;
            UpdateSelectingItem();
        }

    }

    void UpdateInventory() 
    {
        List<CustomDataStructure.itemStack> stacks = Inventory.stacks;
        for (int i = 0; i < slots.Length; i++) 
        {
            if (i < stacks.Count)
                slots[i].ShowStack(stacks[i]);
            else
                slots[i].Empty();
        }

        if (stacks.Count > slots.Length)
        {
            Debug.Log("Not Enough Slot.");
        }

        UpdateSelectingItem();
    }

    void UpdateSelectingItem()
    {
        int N = Inventory.stacks.Count;
        if (N <= 0) 
            itemDescription.text = "";
        else
            itemDescription.text = Inventory.stacks[slotPointer].item.desc;
    }

}
