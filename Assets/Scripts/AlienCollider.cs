using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCollider : MonoBehaviour
{
    public GameObject failObject;
    public GameObject successObject;
    public GameObject Block;
    public GameObject alien;
    bool IsCubeFallenBackward()//�ܰ����� ��ϰ� �浹�Ͽ��� �� ����� �Ѿ���� �߰����� ����
    {
        float cubeRotationX = Block.transform.rotation.eulerAngles.x;
        float cubeRotationZ = Block.transform.rotation.eulerAngles.z;

        // ȸ�� ���� 180���� ���� ��츦 ����Ͽ� 180�� ���ݴϴ�.
        if (cubeRotationX > 180f)
            cubeRotationX -= 360f;
        if (cubeRotationZ > 180f)
            cubeRotationZ -= 360f;

        // ����� �ڷ� �Ѿ����� �� true�� ��ȯ�մϴ�.
        if (cubeRotationX >= 20f || cubeRotationZ >= 20f)
            return true;
        else
            return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            // Alien �Ǵ� Player�� �浹�� ���
            failObject.SetActive(true); // ���ӽ��з� �����ϴ� UIȰ��ȭ
            Time.timeScale = 0f;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("cube"))
        {
            successObject.SetActive(true);
            // cube�� �浹�� ���
            if (IsCubeFallenBackward())
            { 
                successObject.SetActive(true);
                Time.timeScale = 0f; // ���Ӽ������� �����ϴ� UIȰ��ȭ
                alien.SetActive(false);
            }
        }
    }

}


