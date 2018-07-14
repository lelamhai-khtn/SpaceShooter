using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuy : MonoBehaviour {
    [HideInInspector]
    public int id;
    public void BuyItem()
    {
        if(id == 0)
        {
            return;
        }
        
        for (int i = 0; i < ListView.lv.listData.Count; i++)
        {
            if (ListView.lv.listData[i].id == id && !ListView.lv.listData[i].buy)
            {
                if(ManagerGame.managerGame.RequestMoney(ListView.lv.listData[i].price))
                {
                    ListView.lv.listData[i].buy = true;
                    ManagerGame.managerGame.ReduceMoney(ListView.lv.listData[i].price);
                } else
                {
                    print("You can not afford it!");
                }
            }
        }
        ListView.lv.UpdateSpriteBuy(id);
    }
}
