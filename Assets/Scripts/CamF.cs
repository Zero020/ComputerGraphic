using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamF : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        transform.position = target.position;
    }
}
