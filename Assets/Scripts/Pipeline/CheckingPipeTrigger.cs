using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingPipeTrigger : MonoBehaviour
{
    public PipeTrigger[] pipes;
    void OnEnable()
    {
        pipes = GetComponentsInChildren<PipeTrigger>();
        PipeController.checkingPipeTriggers.Add(gameObject.GetComponent<CheckingPipeTrigger>());
    }

    private void OnDestroy()
    {
        PipeController.checkingPipeTriggers.Remove(gameObject.GetComponent<CheckingPipeTrigger>());
    }

    public bool CheckingConnections()
    {
        int trueConnect = 0;
        foreach (var pipe in pipes)
        {
            if (pipe.isTrigger)
            {
                trueConnect++;
            }
        }
        if (trueConnect == pipes.Length)
        {
            //PipeController.checkingPipeTriggers.Add(gameObject.GetComponent<CheckingPipeTrigger>());
            return true;

        }
        else
        {
            //PipeController.checkingPipeTriggers.Remove(gameObject.GetComponent<CheckingPipeTrigger>());
            return false;
        }
    }
}
