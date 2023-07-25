using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_ : MonoBehaviour
{
    
     public GameObject rayobj;
    public GameObject player;
    public float maxDistance;
    public static GameObject _hit;
    public static int a;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControll.active_camera == true)
        {
            ray();

        }
        else
            a = 0;
    }
    public void ray()
    {
       // Debug.Log(a);
        Vector3 direction = transform.forward;
        Vector3 origin = rayobj.transform.position;
        Ray ray = new Ray(origin, direction);
        // Debug.DrawRay(origin, direction, Color.red, 100);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            _hit = hit.collider.gameObject;
            if (_hit.gameObject.tag == "Item")
            {
                a = 1;
            }
            if(_hit.gameObject.tag == "Resource")
            {
                a = 2;
            }
            if(_hit.gameObject.tag == "Tool")
            {
                a = 3;
            }
            if(_hit.gameObject.tag == "chest")
            {
                a = 4;
            }



        }
        else
        {

            _hit = null;
            a = 0;

        }
    }
}
