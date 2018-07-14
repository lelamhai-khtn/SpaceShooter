using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour {
    //public ShopModel item;
    public ListView managerList;
    public float money = 0;
    public static ManagerGame managerGame;
    public Text txtMoney;
    public bool flag = false;

    [HideInInspector]
    public ShopModel item;
    public Text nameItem;
    public Text priceItem;
    public Image imageItem;
    public GameObject btnBuy;
    public GameObject btnUsing;
    // Use this for initialization
    void Start () {
        managerGame = this;
        //CurrentItem();
        DataFirstItem();
        UpdateIU();
        UpdateUIDetail();
    }

	// Update is called once per frame
	void Update () {
        //if (managerList.GetComponent<ListView>().flag)
        //{
        //    CurrentItem();
        //    managerList.GetComponent<ListView>().flag = false;
        //}
        
    }

    //void currentitem()
    //{
    //    detail.getcomponent<itemdetail>().item = managerlist.getcomponent<listview>().itemfirst();
    //    detail.getcomponent<itemdetail>().showdetailitem();
    //}

    //void UpdateDetail()
    //{
    //    print(11);
    //    detail.GetComponent<ItemDetail>().flagDetail = managerList.GetComponent<ListView>().SendStatus();
    //}

    public void AddMoney(float amount)
    {
        money += amount;
        UpdateIU();
    }

    public void ReduceMoney(float amount)
    {
        money -= amount;
        UpdateIU();
    }

    public bool RequestMoney(float amount)
    {
        if(amount <= money)
        {
            return true;
        }
        return false;
    }

    void UpdateIU()
    {
        txtMoney.text = "$" + money.ToString("N1");
    }

    public void DataFirstItem()
    {
        item = ListView.lv.listData[0];
    }

    public void DataItem(ShopModel model)
    {
        item = model;
        UpdateUIDetail();
    }

    private void UpdateUIDetail()
    {
        nameItem.text = item.name;
        priceItem.text = item.price.ToString();
        imageItem.sprite = item.image;
        if (item.buy)
        {
            btnUsing.GetComponent<Button>().interactable = true;
            if (item._using)
            {
                ColorBlock color = btnUsing.GetComponent<Button>().colors;
                color.normalColor = Color.red;
                color.highlightedColor = Color.red;
                btnUsing.GetComponent<Button>().colors = color;
            }
            else
            {
                ColorBlock color = btnUsing.GetComponent<Button>().colors;
                color.normalColor = Color.white;
                color.highlightedColor = Color.white;
                btnUsing.GetComponent<Button>().colors = color;
            }
        }
        else
        {
            btnUsing.GetComponent<Button>().interactable = false;
        }
    }

    public void ClickBuy()
    {
        if (item.id == 0)
        {
            return;
        }

        for (int i = 0; i < ListView.lv.listData.Count; i++)
        {
            if (ListView.lv.listData[i].id == item.id && !ListView.lv.listData[i].buy)
            {
                if (ManagerGame.managerGame.RequestMoney(ListView.lv.listData[i].price))
                {
                    ListView.lv.listData[i].buy = true;
                    ReduceMoney(item.price);
                }
                else
                {
                    print("You can not afford it!");
                }
            }
        }
        ListView.lv.UpdateSpriteBuy(item.id);
    }

    public void ClickUsing()
    {
        if (item.id == 0)
        {
            return;
        }

        for (int i = 0; i < ListView.lv.listData.Count; i++)
        {
            if (ListView.lv.listData[i].id == item.id && !ListView.lv.listData[i]._using)
            {
                ListView.lv.listData[i]._using = true;
            }
            else if (ListView.lv.listData[i]._using)
            {
                ListView.lv.listData[i]._using = false;
            }
        }
        ListView.lv.UpdateSpriteUsing(item.id);
    }
}
