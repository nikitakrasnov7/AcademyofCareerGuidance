using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCL : MonoBehaviour
{
    public int CountTriggers;

    private void OnEnable()
    {
        ControllerCL.Triggers.Add(GetComponent<TriggerCL>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountTriggers++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CountTriggers--;
    }
}
