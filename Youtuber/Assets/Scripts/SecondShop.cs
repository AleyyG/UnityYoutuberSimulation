using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondShop : MonoBehaviour
{
    public static SecondShop Current;
    public GameObject item;
    public List<ItemsSecond> items;
    public Text notMoney;
    public GameObject shopPanel;
    public int price;
    GameObject webcam, pcCase, monitor, keyboard, mouse, microphone;

    void Start()
    {
        price = PlayerPrefs.GetInt("touchCount"); 
        webcam = GameObject.Find("webcam");
        pcCase = GameObject.Find("case");
        monitor = GameObject.Find("monitor");
        microphone = GameObject.Find("microphone");
        mouse = GameObject.Find("mouse");
        keyboard = GameObject.Find("keyboard");
        GetShop();
        Current = this;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].isGet = GetBool("isGet" + i + "0");
            items[i].unlockedLevel = PlayerPrefs.GetInt("unlockedLevel" + i + "0");
            for (int j = 0; j < items[i].levels.Length; j++)
            {
                items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString() + "0");

            }
        }
        ChangeSprite();
    }

    void Update()
    {
        price = PlayerPrefs.GetInt("touchCount");
        for (int i = 0; i < items.Count; i++)
        {
            items[i].isGet = GetBool("isGet" + i + "0");
            items[i].unlockedLevel = PlayerPrefs.GetInt("unlockedLevel" + i + "0");
            for (int j = 0; j < items[i].levels.Length; j++)
            {
                items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString() + "0");
            }
        }
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

    void ChangeSprite()
    {
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].levels.Length; j++)
            {
                Shop.Current.items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString());
                if (Shop.Current.items[i].levels[j].isGet == true)
                {
                    switch (Shop.Current.items[i].itemName)
                    {
                        case "case":
                            pcCase.GetComponent<SpriteRenderer>().sprite = Shop.Current.items[i].levels[Shop.Current.items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "monitor":
                            monitor.GetComponent<SpriteRenderer>().sprite = Shop.Current.items[i].levels[Shop.Current.items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "keyboard":
                            keyboard.GetComponent<SpriteRenderer>().sprite = Shop.Current.items[i].levels[Shop.Current.items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "mouse":
                            mouse.GetComponent<SpriteRenderer>().sprite = Shop.Current.items[i].levels[Shop.Current.items[i].unlockedLevel - 1].levelSprite;
                            break;
                    }
                }
            }
        }
        for(int i = 0; i<items.Count; i++)
        {
            for(int j = 0; j<items[i].levels.Length; j++)
            {
                items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString() + "0");
                if(items[i].levels[j].isGet == true)
                {
                    switch (items[i].itemName)
                    {
                        case "microphone":
                            microphone.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "webcam":
                            webcam.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "case":
                            pcCase.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "monitor":
                            monitor.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "keyboard":
                            keyboard.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
                            break;
                        case "mouse":
                            mouse.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
                            break;
                    }
                }
            }
        }
    }

    void GetShop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject gameObject = Instantiate(item, transform);
            int tempId = i;
            if (GetBool("isGet" + i + "0"))
            {
                gameObject.transform.Find("Image").GetComponent<Image>().sprite = items[i].itemSprite;
                gameObject.transform.Find("LockedPanel").gameObject.SetActive(false);
                gameObject.transform.Find("buyButton").gameObject.SetActive(false);
                gameObject.transform.Find("upgradeButton").gameObject.SetActive(true);
                gameObject.transform.Find("LevelText").gameObject.SetActive(true);
                gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: 0";
                gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = " Upgrade Value: " + items[i].levels[0].upgradeValue.ToString();
                gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[i].levels[0].upgradePrice.ToString() + " View";
                gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: 0";
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.RemoveAllListeners();
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.AddListener(() => UpgradeItem(tempId, gameObject));
                for (int j = 0; j < items[i].levels.Length; j++)
                {
                    if (GetBool("isGetUpgrade" + i.ToString() + j.ToString() + "0"))
                    {
                        if (PlayerPrefs.GetInt("unlockedLevel" + i + "0") == items[i].levels.Length) // burada hata olabilir sonra kontrol et
                        {
                            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: " + items[i].levels[j].upgradeValue.ToString();
                            gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "MAX LEVEL";
                            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[i].levels[j].upgradePrice.ToString() + " View";
                            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + (PlayerPrefs.GetInt("unlockedLevel" + i + "0")); // buraya farklı bir şey yazmam gerek
                            gameObject.transform.Find("upgradeButton").GetComponent<Button>().enabled = false;
                            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = "MAX LEVEL";
                        }
                        else
                        {
                            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: " + items[i].levels[j].upgradeValue.ToString();
                            gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "Upgrade Value: " + items[i].levels[PlayerPrefs.GetInt("unlockedLevel" + i + "0")].upgradeValue.ToString(); // burada hata olabilir.
                            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[i].levels[PlayerPrefs.GetInt("unlockedLevel" + i + "0")].upgradePrice.ToString() + " View"; // burada hata olabilir.
                            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + (PlayerPrefs.GetInt("unlockedLevel" + i + "0")).ToString();
                            gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.RemoveAllListeners();
                            gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.AddListener(() => UpgradeItem(tempId, gameObject));
                        }
                    }
                }
            }
            else
            {
                gameObject.transform.Find("Image").GetComponent<Image>().sprite = items[i].itemSprite;
                gameObject.transform.Find("UpgradeValue").gameObject.SetActive(false);
                gameObject.transform.Find("NowValue").gameObject.SetActive(false);
                gameObject.transform.Find("upgradeButton").gameObject.SetActive(false);
                gameObject.transform.Find("LevelText").gameObject.SetActive(false);
                gameObject.transform.Find("buyButton").gameObject.SetActive(true);
                gameObject.transform.Find("buyButton").transform.GetChild(0).GetComponent<Text>().text = items[i].price.ToString() + " View";
                gameObject.transform.Find("LockedPanel").gameObject.SetActive(true);
                gameObject.transform.Find("buyButton").GetComponent<Button>().onClick.RemoveAllListeners();
                gameObject.transform.Find("buyButton").GetComponent<Button>().onClick.AddListener(() => BuyItem(tempId, gameObject));
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.RemoveAllListeners();
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.AddListener(() => UpgradeItem(tempId, gameObject));
            }
        }
    }
    void BuyItem(int id, GameObject gameObject)
    {
        if (price >= items[id].price && !GetBool("isGet" + id + "0"))
        {
            gameObject.transform.Find("buyButton").gameObject.SetActive(false);
            gameObject.transform.Find("LockedPanel").gameObject.SetActive(false);
            gameObject.transform.Find("LevelText").gameObject.SetActive(true);
            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + items[id].unlockedLevel.ToString();
            gameObject.transform.Find("upgradeButton").gameObject.SetActive(true);
            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[id].levels[items[id].unlockedLevel].upgradePrice.ToString() + " View";
            gameObject.transform.Find("UpgradeValue").gameObject.SetActive(true);
            gameObject.transform.Find("NowValue").gameObject.SetActive(true);
            gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "Upgrade Value: " + items[id].levels[items[id].unlockedLevel].upgradeValue.ToString();
            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: 0 ";
            Events.Current.setView(items[id].price);
            SetBool("isGet" + id + "0", true);
        }
        else
        {
            notMoney.gameObject.SetActive(true);
            notMoney.GetComponent<Animator>().SetTrigger("click");
        }
    }

    void UpgradeItem(int id, GameObject gameObject)
    {
        if (price >= items[id].levels[items[id].unlockedLevel].upgradePrice)
        {
            items[id].unlockedLevel++;
            PlayerPrefs.SetInt("unlockedLevel" + id + "0", items[id].unlockedLevel);
            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + (items[id].unlockedLevel).ToString();
            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: " + items[id].levels[items[id].unlockedLevel - 1].upgradeValue.ToString();
            if (items[id].unlockedLevel == items[id].levels.Length)
            {
                gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "MAX LEVEL";
                gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = "MAX LEVEL";
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().enabled = false;
                Events.Current.setView(items[id].levels[items[id].unlockedLevel - 1].upgradePrice);
                int tempValue = items[id].unlockedLevel - 1;
                SetBool("isGetUpgrade" + id.ToString() + tempValue.ToString() + "0", true); // buradan dolayı hata alıyor olablirim.
                ChangeSprite();
            }
            else
            {
                gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[id].levels[items[id].unlockedLevel].upgradePrice.ToString() + " View";
                gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "Upgrade Value: " + items[id].levels[items[id].unlockedLevel].upgradeValue.ToString();
                Events.Current.setView(items[id].levels[items[id].unlockedLevel - 1].upgradePrice);
                int tempValue = items[id].unlockedLevel - 1;
                SetBool("isGetUpgrade" + id.ToString() + tempValue.ToString() + "0", true);
                Events.Current.setX(items[id].levels[items[id].unlockedLevel - 1].upgradeValue / 10);
                ChangeSprite();
            }
        }
        else
        {
            notMoney.gameObject.SetActive(true);
            notMoney.GetComponent<Animator>().SetTrigger("click");
        }
    }

}
[System.Serializable]
public class ItemsSecond
{
    public Sprite itemSprite;
    public string itemName;
    public bool isGet;
    public int unlockedLevel = 1;
    public int price;
    public LevelSecond[] levels;
}
[System.Serializable]
public class LevelSecond
{
    public Sprite levelSprite;
    public bool isGet;
    public float upgradeValue;
    public int upgradePrice;
}

