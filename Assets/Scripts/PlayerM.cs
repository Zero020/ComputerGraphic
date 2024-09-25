using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public float moveSpeed = 15f;
    CharacterController cc;
    float gravity = -20f;
    float yVelocity = 0;
    public float jumpPower = 5f;
    public bool isJumping = false;
    public int hp = 20;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //bool fire = Input.GetButtonDown("Jump");
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);
        transform.position += dir * moveSpeed * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }

        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }

        if (Input.GetButton("Jump")&& !isJumping)
        {
            yVelocity = jumpPower;
            isJumping=true;
        }
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }

}
