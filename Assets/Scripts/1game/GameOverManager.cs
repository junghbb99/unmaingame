using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void OnPressPlayAgain()
    {
        // 설명: 게임을 다시 시작한다.
        SceneManager.LoadScene("GameScene");
    }
    
    public void OnPressMenu()
    {
        // 설명: 메인 메뉴로 돌아간다.
        SceneManager.LoadScene("MainMenuScene");
    }
}
