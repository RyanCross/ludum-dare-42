using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public static CountdownController instance;

    public int timeLeft = 3;
    public Text countdown;
    private float waitSeconds = 0.5f;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    void Update()
    {
        if(timeLeft == 0)
        {
            countdown.text = ("Go!");
        }
        else if(timeLeft > 0)
        {
            countdown.text = ("" + timeLeft);
        }
        else
        {
            countdown.text = ("");
        }
    }

    public void StartRaceCountdown()
    {
        Debug.Log("Start Countdown");
        StartCoroutine("StartCountdown");
    }
    
    IEnumerator StartCountdown()
    {
        while (timeLeft >= 0)
        {
            yield return new WaitForSeconds(waitSeconds);
            timeLeft--;
        }

    }
}