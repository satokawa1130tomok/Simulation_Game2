using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttanData : MonoBehaviour
{
    public string _name;
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int _count;
    public int count
    {
        get { return _count; }
        set { _count = value; }
    }
    public GameObject _obj;
    public GameObject obj
    {
        get { return _obj; }
        set { _obj = value; }
    }

    public GameObject thisButton;
    public static bool a;

    public Button DropButton;



   

    // Start is called before the first frame update
    void Start()
    {
        thisButton = this.gameObject;
        thisButton.GetComponent<Button>();
        a = false;
     
            }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player2.a);
        //if (Input.GetKeyDown(KeyCode.E) && player2.a)
        //{
        //    Debug.Log("buttondata");
        //    Debug.Log(this.gameObject);
        //    Destroy(thisButton);
        //    a = true;
        //}
    }
    //public void destroybutton()
    //{
    //    Debug.Log("buttondata");
    //    Debug.Log(this.gameObject);
    //    Destroy(this.gameObject);
    //}
    public void OnClick()
    {
        Drop dor = DropButton.GetComponent<Drop>();
        dor.obj = obj;
    }
   
     
}

    

