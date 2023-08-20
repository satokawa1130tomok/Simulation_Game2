using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChestManager : MonoBehaviour
{
    public List<string> ListName;
    public List<int> ListCount;
    public List<GameObject> ListObj;

    public List<Button> but;

    public Button Clone;
    public GameObject content;

    public GameObject SecoundInventoy;
    public player2 _player2;
    public IncentoryCreate _inventoryCrate;
    public InventoryList _inventoryList;
    // Start is called before the first frame update
    void Start()
    {
        ListName.Clear();
        ListCount.Clear();
        ListObj.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SecoundInventoy.activeSelf == true)
            {
                bool a = false;
                Chset(a);
            }
        }
    }

    public void Chset(bool check)
    {
        SecoundInventoy.SetActive(check);
        _player2.inventoy.SetActive(check);
        Cursor.visible = check;
        if (check)
        {
            _player2._inventoryCreate.InventoryCreate();
            //ListCerate();
           
        }
        else
        {
            _player2._inventoryCreate.DestroyButton();
           // DestroyButton();
        }
        


    }

    public void RemoveButton()
    {
        //Debug.Log("a");
        //Debug.Log(Drop.No);
        //Debug.Log(_inventoryList.name[Drop.No]);
        var var1 = -100;
        var1 = ListName.IndexOf(_inventoryList.name[Drop.No]);
       // Debug.Log(var1);
        
        if (var1 == -1)
        {
            ListName.Add(_inventoryList.name[Drop.No]);
            ListCount.Add(1);
            ListObj.Add(_inventoryList.obj[Drop.No]);
        }
        else
        {
            int i;
            i = ListCount[var1];
            i = i + 1;
            ListCount[var1] = i;
        }
        ListCerate();
        InventoryRemove();
        //_inventoryCrate.InventoryCreate();
    }
    public void AddButton()
    {
        var var1 = -100;
        var1 = _inventoryList.name.IndexOf(ListName[Drop.No]);
        // Debug.Log(var1);

        if (var1 == -1)
        {
            _inventoryList.name.Add(ListName[Drop.No]);
            _inventoryList.count.Add(1);
            _inventoryList.obj.Add(ListObj[Drop.No]);
        }
        else
        {
            int i;
            i = _inventoryList.count[var1];
            i = i + 1;
            _inventoryList.count[var1] = i;
        }
        _inventoryCrate.InventoryCreate();
        chestRemove();

    }
    public void ListCerate()
    {
        if(ListName.Count != 0)
        {
            DestroyButton();
        }

        but.Clear();
        // Debug.Log(string.Join(",", but.Select(but => but.ToString())));


        //    int i = 1;
        //    foreach (string a in _InventoryList.name)
        //    {
        //        RectTransform posi = CloneButton.GetComponent<RectTransform>();
        //        CloneButton = (Button)Instantiate(CloneButton_) as Button;//(i+10+interval)*-1
        //        CloneButton.transform.parent = content.transform;
        //        CloneButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (-(i + 1) * 30));

        //        text = CloneButton.gameObject.transform.FindChild("clonetext").gameObject;
        //        Text _text = text.gameObject.GetComponent<Text>();
        //        int b;
        //        b = _InventoryList.count[i - 1];
        //        _text.text = a + " Å~" + b;
        //        i++;
        //        but.Add(CloneButton);

        //        buttanData data = CloneButton.GetComponent<buttanData>();
        //        data.name = a;
        //        data.count = b;
        //        data.obj = _InventoryList.obj[i];


        //    }

        int i = 0;

        int C = ListName.Count;
        C = C - 1;
        //Debug.Log(ListName.Count);
        //Debug.Log(C);
        for (i = 0; i < C + 1; i++)
        {
            //Debug.Log("b");
            string a = ListName[i];
            Button cloneButton = Instantiate(Clone) as Button;
            cloneButton.transform.SetParent(content.transform, false);
            cloneButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(i + 1) * 30);

            GameObject textObj = cloneButton.transform.Find("clonetext").gameObject;
            Text _text = textObj.GetComponent<Text>();

            int b = ListCount[i];
            _text.text = a + " Å~" + b;

            but.Add(cloneButton);

            buttanData data = cloneButton.GetComponent<buttanData>();
            data.number = i;
            // data.obj = _InventoryList.obj[i];
            // Debug.Log(i + "  " + C);
        }
    }
    public void DestroyButton()
    {
        //// Debug.Log("1  " +(string.Join(",", but.Select(but => but.ToString()))));

        foreach (Button a in but)
        {
            Destroy(a.gameObject);

        }
        //   Debug.Log("2  "+(string.Join(",", but.Select(but => but.ToString()))));
    }   //but = new List&It;string&gt();
    public void InventoryRemove()
    {
        //Debug.Log("a");
         int count =_inventoryList.count[Drop.No];
        if(count == 1)
        {
            _inventoryList.name.RemoveAt(Drop.No);
            _inventoryList.count.RemoveAt(Drop.No);
            _inventoryList.obj.RemoveAt(Drop.No);
        }
        else
        {
            _inventoryList.count[Drop.No] = count-1;
        }
        _inventoryCrate.DestroyButton();
        _inventoryCrate.InventoryCreate();
    }
    public void chestRemove()
    {
        Debug.Log("a");
        int count = ListCount[Drop.No];
        if (count == 1)
        {
            ListName.RemoveAt(Drop.No);
            ListCount.RemoveAt(Drop.No);
            ListObj.RemoveAt(Drop.No);
        }
        else
        {
            ListCount[Drop.No] = count - 1;
        }
        DestroyButton();
        ListCerate();

    }
}
