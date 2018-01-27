﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public Text Text;
    public int DelayBeforShow = 2;
    private int TimeLeft;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Init()
    {
        GameplayMasterRef.EStartLevel += Play;
        gameObject.SetActive(false);
    }

    private void Play(bool isStart)
    {
        if (isStart)
        {
            TimeLeft = 10 - DelayBeforShow;
            Invoke("ReduceTimer", DelayBeforShow);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void ReduceTimer()
    {
        TimeLeft--;
        UnityEngine.Debug.Log(TimeLeft);
        Text.text = TimeLeft > 9 ? TimeLeft.ToString() : "0" + TimeLeft.ToString();
        if (TimeLeft == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            Invoke("ReduceTimer", 1);
        }
    }


}
