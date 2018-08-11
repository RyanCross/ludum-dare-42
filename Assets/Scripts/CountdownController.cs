using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{

    public int timeLeft = 3;
    public Text countdown;
    private float waitSeconds = 0.5f;

    void Start()
    {
        StartCoroutine("StartCountdown");
    }

    void Update()
    {
        if(timeLeft == 0)
        {
            countdown.text = ("Go!");
        }
        else
        {
            countdown.text = ("" + timeLeft);
        }
    }
    
    IEnumerator StartCountdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(waitSeconds);
            timeLeft--;
        }

    }
}