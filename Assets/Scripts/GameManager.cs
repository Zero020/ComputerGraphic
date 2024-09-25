using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject StartBefore;
    public GameObject StartNext;
    public GameObject SuccessImage;
  
    public enum GameState
    {
        Ready,
        Run,
        GameFail,
        GameSuccess
    }

    float startTime;
    public GameState gState;

    void Start()
    {
        startTime = Time.time;
        gState = GameState.Ready;
        //FailImage.SetActive(false);
        SuccessImage.SetActive(false);
        //Time.timeScale = 0f;
        StartCoroutine(ReadyToStart());
        
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        
        if (gState == GameState.Ready && elapsedTime >= 5)
        {
            gState = GameState.Run;
            Time.timeScale = 1f;
        }
    }
    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2.5f);
        StartBefore.SetActive(false);
        yield return new WaitForSeconds(5f);
        StartNext.SetActive(false);
        Time.timeScale = 1f;
    }
}

