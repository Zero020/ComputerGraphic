using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MouseWheelSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void Update()
    {
        // 마우스 휠 버튼을 누를 때 소리를 재생합니다.
        if (Input.GetMouseButtonDown(2)) // 마우스 휠 버튼은 2번에 해당합니다.
        {
            // 소리 재생 로직을 여기에 작성합니다.
            PlaySound();
        }
    }

    private void PlaySound()
    {
        // AudioSource 컴포넌트가 존재하면 소리를 재생합니다.
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
