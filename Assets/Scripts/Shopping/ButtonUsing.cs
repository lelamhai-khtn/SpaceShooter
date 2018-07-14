using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonUsing : MonoBehaviour {
    [HideInInspector]
    public int id;
    public void ButtonUsingItem()
    {
        if (id == 0)
        {
            return;
        }

        for (int i = 0; i < ListView.lv.listData.Count; i++)
        {
            if (ListView.lv.listData[i].id == id && !ListView.lv.listData[i]._using)
            {
                ListView.lv.listData[i]._using = true;
            } else if(ListView.lv.listData[i]._using)
            {
                ListView.lv.listData[i]._using = false;
            }
        }
        ListView.lv.UpdateSpriteUsing(id);
    }
}
