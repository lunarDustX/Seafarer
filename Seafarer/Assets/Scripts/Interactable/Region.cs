using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Region : MonoBehaviour
{
    public UnityEvent OnRegionEnter;
    public UnityEvent OnRegionLeave;

    public bool displayRegionName;
    [Header("RegionInfo")]
    public string regionName;

    void Start()
    {
        if (displayRegionName)
        {
            OnRegionEnter.AddListener(DisplayRegionName);
            OnRegionLeave.AddListener(HideRegionName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnRegionEnter != null)
                OnRegionEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnRegionLeave != null)
                OnRegionLeave.Invoke();
        }
    }

    public void DisplayRegionName()
    {
        NoticeMgr.Instance.ShowReminder(regionName);
    }

    public void HideRegionName()
    {
        NoticeMgr.Instance.HideReminder();
    }
}
