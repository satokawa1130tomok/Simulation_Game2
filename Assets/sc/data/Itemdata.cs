using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdata : MonoBehaviour
{
    [SerializeField]
    public string _name;
    public string name{
        get { return _name; }
        set { _name = value; }
    }
    public GameObject _Itemobj;
    public GameObject Itemobj
    {
        get { return _Itemobj; }
        set { _Itemobj = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}