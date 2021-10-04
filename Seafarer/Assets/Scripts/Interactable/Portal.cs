using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //public Vector2 destination;
    public Portal connectedPortal;

    [HideInInspector]
    public bool active;

    private void Start()
    {
        active = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("enter " + transform.name);

        if (active && other.CompareTag("Player"))
        {
            connectedPortal.active = false;
            Vector2 destination = connectedPortal.transform.position;
            other.GetComponent<PlayerController>().Teleport(destination);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //print("exit " + transform.name);

        if (!active && other.CompareTag("Player"))
        {
            active = true;
        }
    }
}
