using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResource : Interactable
{
    // 刷新的资源
    public ItemStackData refreshResource;

    // 当前的资源
    private ItemStackData currentResource;

    void Start()
    {
        Refresh();
    }

    public void BePicked()
    {
        if (currentResource == null)
        {
            SaySomething("资源为空");
            return;
        }

        AddItem(currentResource);
        currentResource = null;
    }

    // 资源刷新
    public void Refresh()
    {
        currentResource = refreshResource;
    }
}
