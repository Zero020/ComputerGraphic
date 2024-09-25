using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public void GameSceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }
}
