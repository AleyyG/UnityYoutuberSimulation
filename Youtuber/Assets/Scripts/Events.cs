using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public static Events Current;
    float touchCount, touchPower, viewsPerSecond, x;
    public Text countText, botFactorText, botPriceText, notMoney;
    public GameObject shopPanel, gamePanel;
    public GameObject leftArrow, rightArrow, topArrow, topRightArrow, cam;
    int roomNumber = 1;
    int botPrice;
    void Start()
    {
        StartCoroutine(OpenCloseShop());
        Current = this;
        x = PlayerPrefs.GetInt("xValue");
        viewsPerSecond = 1f;
        touchCount = PlayerPrefs.GetInt("touchCount");
        touchPower = getTouchPower();
        botPrice = getBotPrice();
        botPriceText.text = botPrice.ToString();
        botFactorText.text = "x" + touchPower;
    }
    void Update()
    {
        viewsPerSecond = x * Time.deltaTime;
        touchCount += viewsPerSecond;
        PlayerPrefs.SetInt("touchCount", (int)touchCount);
        setCountText();

    }
    IEnumerator OpenCloseShop() // sahip olunan spriteları değiştirmek için bunu yapmam gerekiyor çünkü kod hiyerarşideki set active false olan bir nesnenin içerisinde kodun çalışması için onu açıp kapatmam gerek
    {
        shopPanel.SetActive(true);
        yield return new WaitForSeconds(.01f);
        shopPanel.SetActive(false);
    }
    public void setCountText()
    {
        countText.text = ((int)touchCount).ToString();
    }
    public float getTouchPower()
    {
        if (PlayerPrefs.GetInt("touchPower") == 0)
        {
            touchPower = 1;
        }
        else
        {
            touchPower = PlayerPrefs.GetInt("touchPower");
        }
        return touchPower;
    }
    public int getBotPrice()
    {
        if (PlayerPrefs.GetInt("botPrice") == 0)
        {
            botPrice = 500;
        }
        else
        {
            botPrice = PlayerPrefs.GetInt("botPrice");
        }
        return botPrice;
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
    public float getX()
    {
        return this.x;
    }
    public void setX(float x)
    {
        this.x += x;
        PlayerPrefs.SetInt("xValue", (int)this.x);
    }
    public int getView()
    {
        return PlayerPrefs.GetInt("touchCount");
    }
    public void setView(int price)
    {
        this.touchCount -= price;
        PlayerPrefs.SetInt("touchCount", (int)touchCount);
        countText.text = ((int)touchCount).ToString();
    }
    public void setViewAdd(int reward)
    {
        this.touchCount += reward;
        PlayerPrefs.SetInt("touchCount", (int)touchCount);
        countText.text = ((int)touchCount).ToString();
    }
    public void BuyFollowers()
    {
        if (touchCount >= botPrice)
        {
            touchCount -= botPrice;
            botPrice *= 2;
            PlayerPrefs.SetInt("botPrice", botPrice);
            touchPower++;
            PlayerPrefs.SetInt("touchPower", (int)touchPower);
            botPriceText.text = botPrice.ToString();
            botFactorText.text = "x" + touchPower;
        }
        else
        {
            notMoney.gameObject.SetActive(true);
            notMoney.GetComponent<Animator>().SetTrigger("click");
        }
    }
    public void TouchCounter()
    {
        touchCount += touchPower;
        PlayerPrefs.SetInt("touchCount", (int)touchCount);
        countText.text = ((int)touchCount).ToString();
        SetBool("timeDif", true);

    }
    public void OpenShop()
    {

        if (GetBool("newHome") == true)
        {
            shopPanel.SetActive(true);
            gamePanel.SetActive(false);
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);
            topArrow.SetActive(false);
            topRightArrow.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(true);
            gamePanel.SetActive(false);
        }

    }
    public void CloseShop()
    {
        if (GetBool("newHome") == true)
        {
            shopPanel.SetActive(false);
            gamePanel.SetActive(true);
            switch (roomNumber)
            {
                case 1:
                    leftArrow.SetActive(true);
                    rightArrow.SetActive(true);
                    break;
                case 2:
                    topRightArrow.SetActive(true);
                    break;
                case 3:
                    topArrow.SetActive(true);
                    break;
                default:
                    Debug.Log("nothing");
                    break;
            }
        }
        else
        {
            shopPanel.SetActive(false);
            gamePanel.SetActive(true);
        }

    }
    public void LeftArrow()
    {
        cam.transform.position = new Vector3(-77f, -39f, -12f);
        topRightArrow.SetActive(true);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        roomNumber = 2;
    }
    public void RightArrow()
    {
        cam.transform.position = new Vector3(53.3f, -35.1f, -12f);
        topArrow.SetActive(true);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        roomNumber = 3;
    }
    public void TopArrow()
    {
        cam.transform.position = new Vector3(-11.5f, -5.5f, -12f);
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        topArrow.SetActive(false);
        roomNumber = 1;
    }
    public void TopRightArrow()
    {
        cam.transform.position = new Vector3(-11.5f, -5.5f, -12f);
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        topRightArrow.SetActive(false);
        roomNumber = 1;
    }
}
