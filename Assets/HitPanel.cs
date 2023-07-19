using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HitPanel : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI text;
    public InventoryList _InventoryList;
    public HaveTool _HaveTool;
    public ErrorMessage _ErrorMessage;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Ray_.a == 1)//tag == item の時
        {
            Panel.SetActive(true);
            Itemdata Idata = Ray_._hit.gameObject.GetComponent<Itemdata>();
            text.text = Idata.name;
            if (Input.GetMouseButtonDown(0))
            {
                _InventoryList.ItemList(Ray_._hit, Idata);//インベントリに追加
            }
        } 
        else if (Ray_.a == 2)//tga == resource　の時
        {
            Panel.SetActive(true);
            ResourceData Rdata = Ray_._hit.gameObject.GetComponent<ResourceData>();
            text.text = (Rdata.itemname + " from " + Rdata.resource_name + "  × " + Rdata.quantity);
            if (Input.GetMouseButtonDown(0))
            {
                if (Rdata._Tooltype == player2.HaveTool) { 
                   Debug.Log("A"); 
                    _InventoryList.ResourceList(Ray_._hit, Rdata);
                }//インベントリに追加}
                else { _ErrorMessage._ErrorMessage("tool do not much"); }
            }
        }
        else if (Ray_.a == 3)//tag == tool の時
        {
            string type = "";
            Panel.SetActive(true);
            ToolData Tdata = Ray_._hit.gameObject.GetComponent<ToolData>();
            if(Tdata.type == 'A') { type = "axe"; }
            if (Tdata.type == 'P') { type = "pickaxe"; }
            if (Tdata.type == 'S') { type = "shovel"; }
            text.text = Tdata.name + " (" + type + ")";

             if (Input.GetMouseButtonDown(0))
            {
                _InventoryList.ToolList(Ray_._hit, Tdata);//インベントリに追加
                _HaveTool.Have(Tdata);//プレイヤーの手に持つ

            }


        }
        else if(Ray_.a == 0)//Ray_._hit == null の時
        {
            Panel.SetActive(false);
            text.text = "";

        }
       

    }
}
