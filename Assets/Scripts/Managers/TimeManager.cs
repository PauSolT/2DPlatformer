using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public Text timeText; 
    float currentLevelTime = 0f;

    bool isCounting = true;

    public void UpdateTimer()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isCounting = !isCounting;

        if (isCounting)
        {
            currentLevelTime += Time.deltaTime;
            timeText.text = currentLevelTime.ToString("0.00");
        }
    }

}
