using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    public Button btnItem;
    public Text nameItem;
    public Text priceItem;
    public Image imageItem;
    public GameObject btnBuy;
    public GameObject btnUsing;
    [HideInInspector]
    public int id;

    private void Start()
    {
        btnItem = GetComponent<Button>();
        btnItem.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        for (int i = 0; i < ListView.lv.listData.Count; i++)
        {
            if (ListView.lv.listData[i].id == id)
            {
                ListView.lv.item = ListView.lv.listData[i];
                ListView.lv.SendItem();
            }
        }
    }
}
