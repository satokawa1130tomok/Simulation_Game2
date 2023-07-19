using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipieButton : MonoBehaviour
{
    public InventoryList inventoryList;
    public ErrorMessage errorMessage;

    public GameObject panel;
    public Text RecipeName;
    public Text Explanation;
    public GameObject ItemButton1;
    public Text ItemText1;
    public GameObject ItemButton2;
    public Text ItemText2;
    public GameObject ItemButton3;
    public Text ItemText3;


    public OnoData onodata;

    public string _name;
    public string name_
    {
        get { return _name; }
        set { _name = value; }
    }
    public string _name1;
    public string name1
    {
        get { return _name1; }
        set { _name1 = value; }
    }
    public int _count1;
    public int count1
    {
        get { return _count1; }
        set { _count1 = value; }
    }
    public int count__;
    public int count_
    {
        get { return count__; }
        set { count__ = value; }
    }
    public int _count2;
    public int count2
    {
        get { return _count2; }
        set { _count2 = value; }
    }
    public int _count3;
    public int count3
    {
        get { return _count3; }
        set { _count3 = value; }
    }

    public string _name2;
    public string name2
    {
        get { return _name2; }
        set { _name2 = value; }
    }
    public string _name3;
    public string name3
    {
        get { return _name3; }
        set { _name3 = value; }
    }
    public GameObject _obj;
    public GameObject obj
    {
        get { return _obj; }
        set { _obj = value; }
    }
    public int a;
    public int a_
    {
        get { return a; }
        set { a = value; }
    }
    public int _count;
    public int count
    {
        get { return _count; }
        set { _count = value; }
    }
    public bool craft;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Onclick(int a)
    {
        switch (a)
        {
            case 1:
                text(onodata.RecipeName, onodata.Explanation);
                ButtonText(onodata.ItemName1, onodata.ItemCount1, onodata.ItemName2, onodata.ItemCount2, "", 0, onodata.ButtonCount);
                active(onodata.ButtonCount);
                obj = onodata.obj;
                count_ = 1;
                name_ = onodata.RecipeName;
                a_ = a;
                break;
        }
    }
    public void click()
    {
       
        craft = true;
        if (count == 1 && craft)
        {
            ItemCraft(name1, count1);
            if (craft) { ItemRemove(name1, count1); }

        }
        else if (count == 2 && craft)
        {
            ItemCraft(name1, count1);
            if (craft) { ItemCraft(name2, count2); }
            
            if (craft){ ItemRemove(name1, count1); ItemRemove(name2, count2); }
        }

        else if (count == 3 && craft)
        {

        }
        else
        {
            craft = false;
        }

                if (craft)
                {
                    var var1 = name.IndexOf(name_);
                    // Debug.Log(var1);
                    if (var1 == -1)
                    {
                        inventoryList.name.Add(name_);
                        inventoryList.count.Add(count_);
                    }
                    else
                    {
                        int i;
                        i = inventoryList.count[var1];
                        i = i + count_;
                        inventoryList.count[var1] = i;
                    }
                    Onclick(a_);
                }
    }
    public void ItemRemove(string name,int count)
    {
        int int1 = inventoryList.count[inventoryList.name.IndexOf(name)];
        var var1 = inventoryList.name.IndexOf(name);
        if (int1 == count)
        {
            inventoryList.name.Remove(name);

            int a = var1;
            inventoryList.count.RemoveAt(a);
        }
        else
        {
            inventoryList.count[var1] = inventoryList.count[var1] - count;
        }
    }
        public void ItemCraft(string name, int count)
        {
            int int1;
            if (inventoryList.name.IndexOf(name) != -1)
            {

                int1 = inventoryList.count[inventoryList.name.IndexOf(name)];
                if (int1 >= count)
                {
                    return;
                }
                else
                {
                    errorMessage._ErrorMessage("don't have the Item");
                    craft = false;
                    return;
                }
            }
            else
            {
                errorMessage._ErrorMessage("don't have the Item");
                craft = false;
                return;
            }
        }
        public void active(int count)
        {
            Debug.Log(count);
            if (panel.activeSelf == false) { panel.SetActive(true); }
            ItemButton1.SetActive(true);
            if (count == 1)
            {
                ItemButton2.SetActive(false);
                ItemButton3.SetActive(false);
            }
            if (count == 2)
            {
                ItemButton2.SetActive(true);
                ItemButton3.SetActive(false);
            }
            if (count == 3)
            {
                ItemButton2.SetActive(true);
                ItemButton3.SetActive(true);
            }


        }
        public void text(string name, string expl)
        {
            RecipeName.text = name;
            Explanation.text = expl;
        }
        public void ButtonText(string Itemname1, int Itemcount1, string Itemname2, int ItemCount2, string Itemname3, int ItemCount3, int _count)
        {
            count = _count;
            if (_count == 1)
            {
                int int1;
                if (inventoryList.name.IndexOf(Itemname1) != -1) { int1 = inventoryList.count[inventoryList.name.IndexOf(Itemname1)]; }
                else int1 = 0;
                ItemText1.text = (Itemname1 + "     " + int1 + "/" + Itemcount1);
                name1 = Itemname1;

                count1 = Itemcount1;

            }
            if (_count == 2)
            {
                int int1;
                if (inventoryList.name.IndexOf(Itemname1) != -1) { int1 = inventoryList.count[inventoryList.name.IndexOf(Itemname1)]; }
                else int1 = 0;
                ItemText1.text = (Itemname1 + "     " + (int1) + "/" + Itemcount1);

                int int2;
                if (inventoryList.name.IndexOf(Itemname1) != -1) { int2 = inventoryList.count[inventoryList.name.IndexOf(Itemname2)]; }
                else int2 = 0;
                ItemText2.text = (Itemname2 + "     " + (int2) + "/" + ItemCount2);
                name1 = Itemname1;
                name2 = Itemname2;

                count1 = Itemcount1;
                count2 = ItemCount2;
            }
            if (_count == 3)
            {
                int int1;
                if (inventoryList.name.IndexOf(Itemname1) != -1) { int1 = inventoryList.count[inventoryList.name.IndexOf(Itemname1)]; }
                else int1 = 0;
                ItemText1.text = (Itemname1 + "     " + int1 + "/" + Itemcount1);

                int int2;
                if (inventoryList.name.IndexOf(Itemname1) != -1) { int2 = inventoryList.count[inventoryList.name.IndexOf(Itemname2)]; }
                else int2 = 0;
                ItemText2.text = (Itemname2 + "     " + int2 + "/" + ItemCount2);

                int int3;
                if (inventoryList.name.IndexOf(Itemname1) != -1) { int3 = inventoryList.count[inventoryList.name.IndexOf(Itemname3)]; }
                else int3 = 0;
                ItemText3.text = (Itemname3 + "     " + int3 + "/" + ItemCount3);
                name1 = Itemname1;
                name2 = Itemname2;
                name3 = Itemname3;

                count1 = Itemcount1;
                count2 = ItemCount2;
                count3 = ItemCount3;
            }
        }
     
}
