using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 100f;
    float mx = 0;
    float my = 0;

    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");
       float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;
        my = Mathf.Clamp(my, -90f, 90f);

        Quaternion targetRotation = Quaternion.Euler(-my, mx, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        transform.eulerAngles = new Vector3(-my, mx, 0);

       Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0);
        transform.eulerAngles+= dir* rotSpeed* Time.deltaTime;
        Vector3 rot = transform.eulerAngles;
        rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        transform.eulerAngles = rot;
    }

}
