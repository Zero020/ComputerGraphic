using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRotate : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        // Player�� �ٶ󺸴� �������� ȸ��
        transform.LookAt(playerTransform);
    }
}
