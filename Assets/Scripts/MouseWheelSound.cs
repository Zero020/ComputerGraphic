using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MouseWheelSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void Update()
    {
        // ���콺 �� ��ư�� ���� �� �Ҹ��� ����մϴ�.
        if (Input.GetMouseButtonDown(2)) // ���콺 �� ��ư�� 2���� �ش��մϴ�.
        {
            // �Ҹ� ��� ������ ���⿡ �ۼ��մϴ�.
            PlaySound();
        }
    }

    private void PlaySound()
    {
        // AudioSource ������Ʈ�� �����ϸ� �Ҹ��� ����մϴ�.
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
