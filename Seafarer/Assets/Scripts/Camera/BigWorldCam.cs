using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWorldCam : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -1);
    }
}
