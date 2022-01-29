using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class Group : MonoBehaviour
{
    [SerializeField]
    private int suites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button(name:"Add Suite")]
    private void AddSuite()
    {
        var newSuite = new GameObject();
        suites++;
        newSuite.name = "Suite" + suites;
        newSuite.transform.parent = this.transform;
    }

}
