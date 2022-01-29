using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class DummyGadget : MonoBehaviour
{
    public GameObject gadgetPrefab;
    public void Die()
    {
        Destroy(this.gameObject);
    }

    [Button(name:"Preview")]
    private void Preview()
    {
        GetComponent<SpriteRenderer>().sprite = gadgetPrefab.GetComponentInChildren<SpriteRenderer>().sprite;
    }

}
