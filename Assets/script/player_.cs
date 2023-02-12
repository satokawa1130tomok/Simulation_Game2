using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_ : MonoBehaviour
{

    public float speed = 2.0f;

    public GameObject mainCamera;              //ÉÅÉCÉìÉJÉÅÉâäiî[óp
    public GameObject playerObject;            //âÒì]ÇÃíÜêSÇ∆Ç»ÇÈÉvÉåÉCÉÑÅ[äiî[óp
    public float rotateSpeed = 1.0f;            //âÒì]ÇÃë¨Ç≥
    public static bool Run = false;
    public Rigidbody rb;
    public float upForce = 5f;
    public bool isGround;

    public static bool run_tf;
    public Slider runslider;
    public int max;
    public int crruent;
    public static float sli_val;

    //sli

    public Image sli_bk;

    //slider
    [SerializeField]
    public Slider slier_;
    public int slier_n;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runslider.value = 5;
        runslider.maxValue = 5;
        sli_bk = GetComponent<Image>();
        sli_bk.color = new Color(255, 255, 255,255);
        slier_n = 0;
    }
    // Update is called once per frame

    void Update()
    {

        if (CameraControll.active_camera == true)
        {
            camera_();
            Move();
            Sli();
            slider();
            Ray_();
        }


        jump();

        UnityEditor.EditorApplication.isPaused = false;

    }
    public void Ray_()
    {
       
    }
    public void  slider()
    {
        slier_.value = slier_n;
        if (Input.GetKey(KeyCode.K))
        {

        }
    }



    public void Sli()
    {

        //Debug.Log("runslider.sc" + "value:" + runslider.value + "player.Run:" + player_.run_tf);

         runslider.value = sli_val;
        if (Input.GetKey(KeyCode.K))
        {
            sli_bk.color = new Color(255, 0,0, 255);
        }
        

    }


    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = Vector3.up * upForce;
            isGround = false;
        }
    }
    public void camera_()
    {

        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        playerObject.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
    }
    public void Move()

    {
        if (this.transform.position.y < -50)
        {
            this.transform.position = new Vector3(0, 10, 0);
        }
        Transform myTransform = this.transform;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        Run = Input.GetKey(KeyCode.LeftShift) && sli_val > 0.0f;
        if (Input.GetKey(KeyCode.W))
        {


            if (Run)
            {

                transform.position += transform.right * (speed * 2) * Time.deltaTime;
                run_tf = true;

            }
            else
            {
                transform.position += transform.right * speed * Time.deltaTime;
                run_tf = true;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        Vector3 worldAngle = myTransform.eulerAngles;
        if (Input.GetKey(KeyCode.LeftShift))//âÒì]
        {
            if (Input.GetKey(KeyCode.Q))
            {
                worldAngle.y -= 5.0f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                worldAngle.y += 5.0f;
            }
        }
        myTransform.eulerAngles = worldAngle;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
