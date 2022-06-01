using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    int price;
    public Text homePriceText;
    void Start()
    {
        price = PlayerPrefs.GetInt("touchCount"); //PlayerPrefs.GetInt("touchCount")
        if (GetBool("newHome") == true)
            SceneManager.LoadScene(1);
    }

    void Update()
    {
        price = PlayerPrefs.GetInt("touchCount");
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

    public void BuyHome()
    {
        if(price >= 750000) // 750000
        {
            SetBool("newHome", true);
            //bu araya bir geçiş sahnesi eklenebilir. Taşınıyor gibi mesela 
            SceneManager.LoadScene(1);
        }
        else
        {
            homePriceText.gameObject.SetActive(true);
            homePriceText.GetComponent<Animator>().SetTrigger("click");
        }
    }
}
