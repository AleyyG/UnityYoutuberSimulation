using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop Current;
    public GameObject item;
    public List<Items> items;
    public Text notMoney;
    public GameObject shopPanel;
    public int price;
    GameObject webcam, pcCase, monitor, headset, keyboard, mouse;
    void Start()
    {
        price = PlayerPrefs.GetInt("touchCount");  // PlayerPrefs.GetInt("touchCount");
        GetShop();
        webcam = GameObject.Find("webcam");
        pcCase = GameObject.Find("case");
        monitor = GameObject.Find("monitor");
        headset = GameObject.Find("headset");
        keyboard = GameObject.Find("keyboard");
        mouse = GameObject.Find("mouse");
        Current = this;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].isGet = GetBool("isGet" + i);
            items[i].unlockedLevel = PlayerPrefs.GetInt("unlockedLevel" + i);
            for (int j = 0; j < items[i].levels.Length; j++)
            {
                items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString());

            }
        }
        ChangeSprite();
    }
    void Update()
    {
        price = PlayerPrefs.GetInt("touchCount");
        for (int i = 0; i < items.Count; i++)
        {
            items[i].isGet = GetBool("isGet" + i);
            items[i].unlockedLevel = PlayerPrefs.GetInt("unlockedLevel" + i);
            for (int j = 0; j < items[i].levels.Length; j++)
            {
                items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString());
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
                items[i].levels[j].isGet = GetBool("isGetUpgrade" + i.ToString() + j.ToString());
                if (items[i].levels[j].isGet)
                {
                    switch (items[i].itemName) //burda bi hata aldım(sonra almadım)
                    {
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
                        case "headset":
                            headset.GetComponent<SpriteRenderer>().sprite = items[i].levels[items[i].unlockedLevel - 1].levelSprite;
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
            if (GetBool("isGet" + i))
            {
                gameObject.transform.Find("Image").GetComponent<Image>().sprite = items[i].itemSprite;
                gameObject.transform.Find("LockedPanel").gameObject.SetActive(false);
                gameObject.transform.Find("buyButton").gameObject.SetActive(false);
                gameObject.transform.Find("upgradeButton").gameObject.SetActive(true);
                gameObject.transform.Find("LevelText").gameObject.SetActive(true);
                gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: 0";
                gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "Upgrade Value: " + items[i].levels[0].upgradeValue.ToString();
                gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[i].levels[0].upgradePrice.ToString() + " View";
                gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: 0";
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.RemoveAllListeners();
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().onClick.AddListener(() => UpgradeItem(tempId, gameObject));
                for (int j = 0; j < items[i].levels.Length; j++)
                {
                    if (GetBool("isGetUpgrade" + i.ToString() + j.ToString()))
                    {
                        if (PlayerPrefs.GetInt("unlockedLevel"+i) == items[i].levels.Length)
                        {
                            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: " + items[i].levels[j].upgradeValue.ToString();
                            gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "MAX LEVEL";  //items[i].levels[j].upgradeValue.ToString();
                            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[i].levels[j].upgradePrice.ToString() + " View";
                            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + (PlayerPrefs.GetInt("unlockedLevel" + i)).ToString();
                            gameObject.transform.Find("upgradeButton").GetComponent<Button>().enabled = false;
                            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = " MAX LEVEL";

                        }
                        else
                        {
                            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: " + items[i].levels[j].upgradeValue.ToString();
                            gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "Upgrade Value: " + items[i].levels[PlayerPrefs.GetInt("unlockedLevel" + i)].upgradeValue.ToString();
                            gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[i].levels[PlayerPrefs.GetInt("unlockedLevel" + i)].upgradePrice.ToString() + " View";
                            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + (PlayerPrefs.GetInt("unlockedLevel" + i)).ToString();
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
        if (price >= items[id].price && !GetBool("isGet" + id))
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
            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: 0 "; /*+ items[id].levels[items[id].unlockedLevel].upgradeValue.ToString();*/
            Events.Current.setView(items[id].price);
            SetBool("isGet" + id, true);
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
            PlayerPrefs.SetInt("unlockedLevel" + id, items[id].unlockedLevel);
            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level: " + (items[id].unlockedLevel).ToString();
            gameObject.transform.Find("NowValue").GetComponent<Text>().text = "Now Value: " + items[id].levels[items[id].unlockedLevel - 1].upgradeValue.ToString();
            if (items[id].unlockedLevel == items[id].levels.Length)
            {
                gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "MAX LEVEL";
                gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = "MAX LEVEL";
                gameObject.transform.Find("upgradeButton").GetComponent<Button>().enabled = false;
                Events.Current.setView(items[id].levels[items[id].unlockedLevel - 1].upgradePrice);
                SetBool("isGetUpgrade" + id.ToString() + (items[id].unlockedLevel - 1).ToString(), true);
                ChangeSprite();
            }
            else
            {
                gameObject.transform.Find("upgradeButton").transform.GetChild(0).GetComponent<Text>().text = items[id].levels[items[id].unlockedLevel].upgradePrice.ToString() + " View";
                gameObject.transform.Find("UpgradeValue").GetComponent<Text>().text = "Upgrade Value: " + items[id].levels[items[id].unlockedLevel].upgradeValue.ToString();
                Events.Current.setView(items[id].levels[items[id].unlockedLevel - 1].upgradePrice);
                SetBool("isGetUpgrade" + id.ToString() + (items[id].unlockedLevel - 1).ToString(), true);
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
public class Items
{
    public Sprite itemSprite;
    public string itemName;
    public bool isGet;
    public int unlockedLevel = 1;
    public int price;
    public Level[] levels;

    public Items(Sprite itemSprite, string itemName, bool isGet, int unlockedLevel, int price)
    {
        this.itemSprite = itemSprite;
        this.itemName = itemName;
        this.isGet = isGet;
        this.unlockedLevel = unlockedLevel;
        this.price = price;
    }
}
[System.Serializable]
public class Level
{
    public Sprite levelSprite;
    public bool isGet;
    public float upgradeValue;
    public int upgradePrice;
}
