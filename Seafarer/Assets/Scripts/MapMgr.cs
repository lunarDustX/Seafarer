using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyButtons;

public class MapMgr : MonoBehaviour
{
    
    [SerializeField] private GameObject isleMark, playerMark;
    [SerializeField] private GameObject mapBg;

    private GameObject player;

    private float mapCellSize;

    private Isle[] isles;

    void Start()
    {
    }

    void Update()
    {
        
    }

    [Button(name:"Refresh Isles")]
    private void RefreshIsles() 
    {
        isles = FindObjectsOfType<Isle>();

        foreach (Isle isle in isles) 
        {
            GameObject mark = GenerateMark(isleMark, isle.transform.position);
            mark.GetComponentInChildren<Text>().text = isle.GetComponent<Isle>().isleName;
        }
    }

    [Button(name:"Refresh Player")]
    private void RefreshPlayer() 
    {
        player = GameObject.FindWithTag("Player");
        GameObject mark = GenerateMark(playerMark, player.transform.position);
    }

    GameObject GenerateMark(GameObject _markPrefab, Vector2 _posInWorld) 
    {
        GameObject mark = Instantiate(_markPrefab, mapBg.transform);
        mark.GetComponent<RectTransform>().anchoredPosition = _posInWorld * mapCellSize;
        return mark;
    }
}
