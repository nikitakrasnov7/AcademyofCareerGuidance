using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public static GameObject ActivePipe;

    public GameObject CheckButton;
    public TextMeshProUGUI ResoultText;

    public static List<CheckingPipeTrigger> checkingPipeTriggers = new List<CheckingPipeTrigger>();

    public void RotatingPipe()
    {
        if (ActivePipe != null)
        {

            ActivePipe.transform.Rotate(Vector3.forward, -90);
        }
    }

    public void DeletePipe()
    {
        if (ActivePipe != null)
        {
            Destroy(ActivePipe);
        }
    }


    public void FinalingChecking()
    {

        if (checkingPipeTriggers.Count > 0)
        {
            int i = 0;
            foreach (var b in checkingPipeTriggers)
            {
                if (b.CheckingConnections())
                {
                    i++;

                }
            }
            if (i == checkingPipeTriggers.Count)
            {
                ResoultText.text = "Все отлично " + checkingPipeTriggers.Count;
            }
            else
            {
                ResoultText.text = "Где то ошибка, проверь себя " + checkingPipeTriggers.Count;
            }
        }
        else
        {
            ResoultText.text = "Вы еше не поставили трубы " + checkingPipeTriggers.Count;

        }
        Debug.Log(checkingPipeTriggers.Count);

    }
}
