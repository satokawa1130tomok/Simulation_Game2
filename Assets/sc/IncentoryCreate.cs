using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class IncentoryCreate : MonoBehaviour
{
    public Button CloneButton_;
    public GameObject content;
    public InventoryList _InventoryList;
    public int interval;
    public GameObject text;
    private Text _text;
    public Canvas canvas;
    public List<Button> but;
    public bool ButtonClause;
    public bool CanvasClause;
    public Button CloneButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && !CanvasClause && ButtonClause)
        //{
        //    CanvasClause = true;
        //    ButtonClause = false;
        //    return;
        //}
        //else if (Input.GetKeyDown(KeyCode.E) && CanvasClause && !ButtonClause)
        //{
        //    CanvasClause = false;

        //}
    }
    public void InventoryCreate() //ボタンを生成
    {

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
        //        _text.text = a + " ×" + b;
        //        i++;
        //        but.Add(CloneButton);

        //        buttanData data = CloneButton.GetComponent<buttanData>();
        //        data.name = a;
        //        data.count = b;
        //        data.obj = _InventoryList.obj[i];


        //    }

        int i = 0;

        int C = _InventoryList.name.Count();

        for (i = 0; i <= C+1; i++)      
        {
            string a = _InventoryList.name[i];
            Button cloneButton = Instantiate(CloneButton_) as Button;
            cloneButton.transform.SetParent(content.transform, false);
            cloneButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(i + 1) * 30);

            GameObject textObj = cloneButton.transform.Find("clonetext").gameObject;
            Text _text = textObj.GetComponent<Text>();

            int b = _InventoryList.count[i];
            _text.text = a + " ×" + b;

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
}


