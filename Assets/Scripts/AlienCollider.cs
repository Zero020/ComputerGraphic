using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCollider : MonoBehaviour
{
    public GameObject failObject;
    public GameObject successObject;
    public GameObject Block;
    public GameObject alien;
    bool IsCubeFallenBackward()//외계인이 블록과 충돌하였을 때 블록이 넘어갔는지 추가조건 삽입
    {
        float cubeRotationX = Block.transform.rotation.eulerAngles.x;
        float cubeRotationZ = Block.transform.rotation.eulerAngles.z;

        // 회전 값이 180도를 넘을 경우를 고려하여 180도 빼줍니다.
        if (cubeRotationX > 180f)
            cubeRotationX -= 360f;
        if (cubeRotationZ > 180f)
            cubeRotationZ -= 360f;

        // 블록이 뒤로 넘어졌을 때 true를 반환합니다.
        if (cubeRotationX >= 20f || cubeRotationZ >= 20f)
            return true;
        else
            return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            // Alien 또는 Player와 충돌한 경우
            failObject.SetActive(true); // 게임실패로 오버하는 UI활성화
            Time.timeScale = 0f;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("cube"))
        {
            successObject.SetActive(true);
            // cube와 충돌한 경우
            if (IsCubeFallenBackward())
            { 
                successObject.SetActive(true);
                Time.timeScale = 0f; // 게임성공으로 오버하는 UI활성화
                alien.SetActive(false);
            }
        }
    }

}


