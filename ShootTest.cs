using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed = 10;
    public int jumpForce = 200;
    bool jump = false;
    float inputX, inputY;

    public float bulletSpeed = 2;
    bool shoot = false;
    public GameObject bullet;
    public Transform bulletPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Jump()
    {
        rb.AddForce(0, jumpForce, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            shoot = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);
        if(jump)
        {
            Jump();
            jump = false;
        }

        if(shoot)
        {
            Shoot();
            shoot = false;
        }
    }

    void Shoot()
    {
        print(transform.position);
        GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
    }
}
