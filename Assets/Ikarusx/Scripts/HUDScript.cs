using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class HUDScript : MonoBehaviour {

    public float timer = 60f;

    public Text timerLabel;
    
	void Start ()
    {
    }
	
	void Update ()
    {
        TimeSpan ts = TimeSpan.FromSeconds(timer);

        timerLabel.text = string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            // die
            timer = 0;
        }
    }
}
