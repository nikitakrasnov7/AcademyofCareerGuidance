using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PipeTrigger : MonoBehaviour
{
    public bool isTrigger = false;
    public GameObject firstPipeConnect;

    private void Start()
    {
        GetComponent<Image>().color = Color.red;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (firstPipeConnect == null)
        {
            if (collision.tag == "Pipe")
            {
                firstPipeConnect = collision.gameObject;
                GetComponent<Image>().color = Color.green;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Pipe")
        {
            isTrigger = true;
            GetComponent<Image>().color = Color.green;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == firstPipeConnect)
        {
            isTrigger = false;
            firstPipeConnect = null;
            GetComponent<Image>().color = Color.red;
        }
    }
}
