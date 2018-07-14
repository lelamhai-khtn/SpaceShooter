using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListView : MonoBehaviour {
    [HideInInspector]
    public ShopModel item;
    public static ListView lv;
    public List<ShopModel> listData = new List<ShopModel>();
    public List<GameObject> itemHolderList = new List<GameObject>();
    
    public GameObject prefb;
    public Transform grid;
    
    public bool flag = true;
    public bool flagStatus = true;
	// Use this for initialization
	void Start () {
        lv = this;
        FillData();
        item = listData[0];
    }
    

    public void FillData()
    {
        int index = listData.Count - 1;
        for (int i = 0; i < listData.Count; i++)
        {
            GameObject holder = Instantiate(prefb, grid);
            Item holderItem = holder.GetComponent<Item>();

            // pass data id
            holderItem.btnItem.GetComponent<Item>().id = listData[i].id;
            holderItem.btnBuy.GetComponent<ButtonBuy>().id = listData[i].id;
            holderItem.btnUsing.GetComponent<ButtonUsing>().id = listData[i].id;

            holderItem.nameItem.text = listData[i].name;
            holderItem.priceItem.text = listData[i].price.ToString("N1");
            holderItem.imageItem.sprite = listData[i].image;

            // add holder
            itemHolderList.Add(holder);

            if (!listData[i].buy)
            {
                holderItem.btnUsing.GetComponent<Button>().interactable = false;
            }

            if (listData[i]._using)
            {
                ColorBlock color = holderItem.btnUsing.GetComponent<Button>().colors;
                color.normalColor = Color.red;
                holderItem.btnUsing.GetComponent<Button>().colors = color;
            }
            index--;
        }
    }

    public void SendItem()
    {
        ManagerGame.managerGame.DataItem(item);
    }
    

    public void UpdateSpriteBuy(int id)
    {
        for (int i = 0; i < itemHolderList.Count; i++)
        {
            // all gameobject item
            Item itemHolderScript = itemHolderList[i].GetComponent<Item>();
            for (int j = 0; j < listData.Count; j++)
            {
                if (listData[i].id == id)
                {
                    itemHolderScript.btnUsing.GetComponent<Button>().interactable = true;
                }
            }
        }
        SendItem();
    }

    public void UpdateSpriteUsing(int id)
    {
        for (int i = 0; i < itemHolderList.Count; i++)
        {
            // all gameobject item
            Item itemHolderScript = itemHolderList[i].GetComponent<Item>();
            for (int j = 0; j < listData.Count; j++)
            {
                if (listData[i].id == id)
                {
                    ColorBlock color = itemHolderScript.btnUsing.GetComponent<Button>().colors;
                    color.normalColor = Color.red;
                    color.highlightedColor = Color.red;
                    itemHolderScript.btnUsing.GetComponent<Button>().colors = color;
                }
                else
                {
                    ColorBlock color = itemHolderScript.btnUsing.GetComponent<Button>().colors;
                    color.normalColor = Color.white;
                    color.highlightedColor = Color.white;
                    itemHolderScript.btnUsing.GetComponent<Button>().colors = color;
                }
            }
        }

        SendItem();
    }
}
