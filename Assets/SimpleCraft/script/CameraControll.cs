using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraControll : MonoBehaviour
{


    public GameObject CameraObject;
    public GameObject mainCamera;              //メインカメラ格納用
    public GameObject playerObject;            //回転の中心となるプレイヤー格納用
    public float rotateSpeed = 2.0f;            //回転の速さ
    public static bool active_camera;
    public float max = 180.0f;


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとユニティちゃんをそれぞれ取得
        //mainCamera = Camera.main.gameObject;
        //playerObject = GameObject.Find("unitychan");
        active_camera = true;
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        //rotateCameraの呼び出し
        if (active_camera == true)
        {
            rotateCamera();
        
        }
        Max();


       
    }

    //カメラを回転させる関数
    private void rotateCamera()
    {
        // //Vector3でX,Y方向の回転の度合いを定義
        // Vector3 angle = new Vector3(0, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        // //transform.RotateAround()をしようしてメインカメラを回転させる
        //// mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        // mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.forward, angle.y);
        Transform myTransform = mainCamera.transform;
        Vector3 worldAngle = myTransform.eulerAngles;
        float MouseY = Input.GetAxis("Mouse Y") * rotateSpeed * -1;
        worldAngle.x += MouseY;
        myTransform.eulerAngles = worldAngle;
        //if ()
        //{
        Vector3 localPos = myTransform.localPosition;
       // localPos.x = MouseY ;
        myTransform.localPosition = localPos;
        //}




        }
    
    private void Max()
    {
        

        
    }
}