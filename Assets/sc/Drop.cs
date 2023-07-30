using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop : MonoBehaviour
{
   
    [SerializeField]
    public static int No;
    public static string name;
    
    public static InventoryList _inventoyList;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public voidÅ@OnClick()
    {
        
        GameObject cloneObj = _inventoyList.obj[No];
        Debug.Log(No);
        Debug.Log(cloneObj);
        GameObject obj =Å@Instantiate(cloneObj, player.transform.position, Quaternion.identity);
        Itemdata scle = obj.GetComponent<Itemdata>();
        //obj.gameObject.transform.localScale = new Vector3(scle.scale, scle.scale, scle.scale);
    }
    
}
