using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnPressGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnPressExit()
    {
        // 설명: 게임을 종료한다.
        Application.Quit();
    }
}