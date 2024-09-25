using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public GameObject fImage;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        fImage.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool fire = Input.GetButtonDown("Jump");
        bool da = Input.GetButtonDown("Mouse ScrollWheel");
        anim.SetFloat("Move", v);
        anim.SetFloat("Turn", h);
        anim.SetBool("Jump", fire);
        anim.SetBool("Damage", da);

    }
   
}
