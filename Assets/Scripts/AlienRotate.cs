using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRotate : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        // Player를 바라보는 방향으로 회전
        transform.LookAt(playerTransform);
    }
}
