using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerPhotorobot : MonoBehaviour
{
    public float StartTime = 30f;
    public float CurrentTime = 30f;
    public TextMeshProUGUI TimerText;

    public bool isStartTimer = false;

    public UnityEvent ActiveInventary;
    //public UnityEvent ResetFace;
    public void Timer()
    {

        isStartTimer = true;
    }

    private void FixedUpdate()
    {
        if (isStartTimer)
        {
            if (CurrentTime >= 0f)
            {
                CurrentTime -= Time.deltaTime;
                TimerText.text = $"00:{Math.Truncate(CurrentTime)}";
            }
            else
            {
                ActiveInventary.Invoke();
                //ResetFace.Invoke();
                isStartTimer = false;
            }
        }
    }


}
