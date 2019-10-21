using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;

    private bool onGround = false;
    private bool letGoOfJump = false;
    private bool isFalling = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3();
        float xSpeed = 0.0f;
        float ySpeed = GetComponent<Rigidbody>().velocity.y;

        xSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if(Input.GetButton("Jump") && !letGoOfJump && !onGround && !isFalling && GetComponent<Rigidbody>().velocity.y <= 0)
        {
            isFalling = true;
        }

        if (Input.GetButton("Jump"))
        {

            if (isFalling)
            {
                ySpeed = 0;
                letGoOfJump = true;
                isFalling = true;
            }
            else
            {
                letGoOfJump = true;
            }
        }

        velocity.x = xSpeed;
        velocity.y = ySpeed;
        GetComponent<Rigidbody>().velocity = velocity;

        if (Input.GetButton("Jump")&& onGround && letGoOfJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            letGoOfJump = false;
            isFalling = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Celing" || collision.gameObject.tag == "UpWall")
        {
            onGround = true;
        }
        else
        {
            Debug.Log("Ha you suck");
        }
    }

}
