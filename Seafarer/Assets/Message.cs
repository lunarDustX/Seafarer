using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public float lifeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", lifeTime);
    }

    void Die()
    {
        NoticeMgr.Instance.DestroyMessage(this.gameObject);
    }


}
