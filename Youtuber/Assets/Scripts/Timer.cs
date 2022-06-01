using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    int lastTime, firstTime, timeDif;
    int touchCount;
    int reward;
    public GameObject rewardPanel;
    public Text rewardText, countText;
    void Start()
    {
        touchCount = PlayerPrefs.GetInt("touchCount");
        if (GetBool("timeDif") == false)
        {
            firstTime = int.Parse(DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
            PlayerPrefs.SetInt("firstTime", firstTime);
        }
        else
        {
            firstTime = PlayerPrefs.GetInt("lastTime");
            timeDif = Mathf.Abs(PlayerPrefs.GetInt("lastTime") - PlayerPrefs.GetInt("firstTime"));
            if (timeDif/10 == 0)
            {
                rewardPanel.SetActive(false);
            }
            else
            {
                rewardPanel.SetActive(true);
                rewardText.text = (timeDif / 10) + " View";
            }
        }
    }
    void Update()
    {
        touchCount = PlayerPrefs.GetInt("touchCount");
        LastTime();
    }
    public static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);

        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AcceptReward()
    {
        reward = timeDif / 10;
        Events.Current.setViewAdd(reward);
        rewardPanel.SetActive(false);
    }
    public void LastTime()
    {
        lastTime = int.Parse(DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
        PlayerPrefs.SetInt("lastTime", lastTime);
    }
}
