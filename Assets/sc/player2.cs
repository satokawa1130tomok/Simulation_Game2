using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    
    public GameObject player;//�v���C���[
    public Rigidbody rb;//�v���C���[�̓����蔻��
    public int speed;//�ړ����x
    public static bool run;//����
    public float rotateSpeed = 1.0f;//���_�ړ����x
    public bool isGround;//�n��
    public float upForce = 10f;//�W�����v��
    public GameObject inventoy;//�C���x���g��
    public IncentoryCreate _inventoryCreate;//�N���X�擾
    public static char HaveTool = 'N';//�����Ă���c�[���̎��
    public static bool a;//inndenntorinoboolstatic
    public buttanData _buttondata;

    public GameObject Craft;
    public GameObject Recipe;
   // Start is called before the first frame update

    //�����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    void Start()
    {
        speed = 10;
        inventoy.SetActive(false);
        Cursor.visible = false;
        a = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            _inventoryCreate.InventoryCreate();
        }
        if (CameraControll.active_camera == true)
        {
            cameramove();

        }

        if (!inventoy.activeSelf) {  move();}
        inventoy_();
        _Craft();
;    }
    public void move()
    {

        if (Input.GetKey(KeyCode.W)&& !run) { transform.position += transform.right*speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S)) { transform.position -= transform.right * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A)) { transform.position += transform.forward * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D)) { transform.position -= transform.forward * speed * Time.deltaTime; }
        if (run) { transform.position += transform.right * speed *2* Time.deltaTime; }


        
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && run_sli.run_value > 0f)
            {

                run = true;
            }
            else
                run = false;

       
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
               isGround = false;
               rb.velocity = Vector3.up * upForce*10;
                
        }
        

    }
    public void cameramove()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        player.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
    }
    public void inventoy_()
    {
        if (Input.GetKeyDown(KeyCode.E)&&(!inventoy.activeSelf) && (!Craft.activeSelf))
        {
          
            inventoy.SetActive(true);
            Cursor.visible = true;
            CameraControll.active_camera = false;
             _inventoryCreate.InventoryCreate();
            a = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && (inventoy.activeSelf) && (!Craft.activeSelf))
        {

            _inventoryCreate.DestroyButton();

            Cursor.visible = false;
            CameraControll.active_camera = true;
            // _inventoryCreate.DestroyButton();
            inventoy.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.E) && (!inventoy.activeSelf) && (Craft.activeSelf))
        {
            Recipe.SetActive(false);
            Craft.SetActive(false);
            inventoy.SetActive(true);
            Cursor.visible = true;
            CameraControll.active_camera = false;
            _inventoryCreate.InventoryCreate();
            a = true;
        }
       


    }
    public void _Craft()
    {
        if (Input.GetKeyDown(KeyCode.C) && (!Craft.activeSelf) && (!inventoy.activeSelf))
        {
            Craft.SetActive(true);
            Recipe.SetActive(false);
            Cursor.visible = true;
            CameraControll.active_camera = false;
        }
        else if (Input.GetKeyDown(KeyCode.C) && (Craft.activeSelf) && (!inventoy.activeSelf))
        {
             Recipe.SetActive(false);
            Craft.SetActive(false);

            Cursor.visible = false;
            CameraControll.active_camera = true;
        }
         else if (Input.GetKeyDown(KeyCode.C) && (!Craft.activeSelf) && (inventoy.activeSelf))
        {
            Craft.SetActive(true);
            Recipe.SetActive(false);
            _inventoryCreate.DestroyButton();

            Cursor.visible = true;
            CameraControll.active_camera = false;
            // _inventoryCreate.DestroyButton();
            inventoy.SetActive(false);
        }
       
    }
    

}
