using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameDirector : MonoBehaviour
{
    public Slider timerSlider;
    public float maxTime = 70f;
    private float currentTime;

    public GameObject FailImage;
    private bool isGameStarted = false;

    private void Start()
    {
        currentTime = maxTime;
        UpdateSliderValue();
       
    }

    private void Update()
    {
        if (!isGameStarted)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            EndGame();
        }

        UpdateSliderValue();
    }

    public bool OkTimeOver = false;

    private void UpdateSliderValue() //�����̴� ��
    {
        timerSlider.value = currentTime / maxTime;
    }

    private IEnumerator StartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isGameStarted = true;
        timerSlider.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(StartGameAfterDelay(8f));
    }

    private void EndGame()
    {
        FailImage.SetActive(true);
        OkTimeOver = true;
    }

    // �����̴� �� ���� �� ȣ��Ǵ� �޼���
    public void OnSliderValueChanged()
    {
        // Slider ���� ���� ���� �ð� ������Ʈ
        currentTime = timerSlider.value * maxTime;
    }
}
