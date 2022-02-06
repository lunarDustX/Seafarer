using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldReminder : MonoBehaviour
{
    public Text reminderTxt;

    [Header("--")]
    public float lifeTime = 2f;
    public float upSpeed = 2f;
    
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
    }

    public void Init(string _content)
    {
        reminderTxt.text = _content;
    }
}
