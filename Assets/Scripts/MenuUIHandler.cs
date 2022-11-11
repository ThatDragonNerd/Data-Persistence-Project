using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text highScoreText;
    private string input;

    void Start()
    {
        MainManager.Instance.LoadHighScore();

        if(MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }

            else
            {
                DisplayName();
            }
        }
        else
        {
            highScoreText.text = "Set a new High Score!";
        }
       
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    void DisplayHighScore()
    {
        highScoreText.text = MainManager.Instance.playerName + "is Number 1!" + MainManager.Instance.highScore + "with" + MainManager.Instance.highScoreName; ; 
    }

    void DisplayName()
    {
        highScoreText.text = MainManager.Instance.playerName + " has the best score!";
    }

    public void StorePlayerName(string inputName)
    {
        MainManager.Instance.playerName = inputName;
    }

    public void Exit()
    {
    
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
             Application.Quit();
#endif

    }
}
