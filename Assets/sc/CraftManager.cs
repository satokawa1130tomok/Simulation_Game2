using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    public RecipieButton recipie;
    public bool craft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        craft = true;
        if(recipie.count == 1)//ボタンの数が1
        {
            check(recipie.name1, recipie.count1);
        }
        if (recipie.count == 2)//ボタンの数が2
        {
            check(recipie.name1, recipie.count1);
            
            check(recipie.name2, recipie.count2);
        }
        if (recipie.count == 3)//ボタンの数が2
        {
            check(recipie.name1, recipie.count1);
            check(recipie.name2, recipie.count2); 
            check(recipie.name3, recipie.count3);
        }

        if (craft)//全部持っていたら
        {
            Craft();
            if (recipie.count == 1)//ボタンの数が1
            {
                RemoveList(recipie.name1, recipie.count1);
            }
            if (recipie.count == 2)//ボタンの数が2
            {
                RemoveList(recipie.name1, recipie.count1);

                RemoveList(recipie.name2, recipie.count2);
            }
            if (recipie.count == 3)//ボタンの数が2
            {
                RemoveList(recipie.name1, recipie.count1);
                RemoveList(recipie.name2, recipie.count2);
                RemoveList(recipie.name3, recipie.count3);
            }
        }
        else
        {
            return;
        }
        Debug.Log(craft);
    }
    public void check(string item,int count)
    {
        if (craft)
        {
            var var_ = 0;
            if (recipie.inventoryList.name.IndexOf(item) == -1)
            {
                var_ = 0;
            }
            else
            {
                var_ = recipie.inventoryList.count[recipie.inventoryList.name.IndexOf(item)];
            }
            if (var_ == -1)//アイテムを持っていない
            {
                craft = false;
                return;
            }
            else if (var_ >= count)//必要な量を満たしている
            {
                craft = true;
                return;
            }
            else if (var_ < count)//足りない
            {
                craft = false;
                return;
            }
            else
            {
                craft = false;
                return;
            }
          
        }
        else
        {
            return;
        }

    }
    public void Craft()
    {
        recipie.inventoryList.CraftItem(recipie.name_, recipie.count_, recipie.obj);
    }
    public void RemoveList(string name, int count)
    {
        var var_ = recipie.inventoryList.count[recipie.inventoryList.name.IndexOf(name)] ;
        if (var_ == count)
        {
           int a= recipie.inventoryList.name.IndexOf(name);
            recipie.inventoryList.name.RemoveAt(a);
            recipie.inventoryList.count.RemoveAt(a);
            recipie.inventoryList.obj.RemoveAt(a);
        }
        else
        {
            recipie.inventoryList.count[recipie.inventoryList.name.IndexOf(name)] =  var_ -  count;
            
        }
    }
    public void Return(int a)
    {
        craft = false;
        if (a == 1) { recipie.errorMessage._ErrorMessage("don't have the Item"); }
        if (a == 2) { recipie.errorMessage._ErrorMessage("Not enough Item"); }
        if (a == 3) { recipie.errorMessage._ErrorMessage("Error!"); }

    }

}
