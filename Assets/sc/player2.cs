using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public GameObject player;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {

        if (Input.GetKey(KeyCode.W)) { transform.position += new Vector3(speed, 0, 0) * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S)) { transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A)) { transform.position += new Vector3(0, 0, speed) * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D)) { transform.position -= new Vector3(0, 0, speed) * Time.deltaTime; }

    }
}
