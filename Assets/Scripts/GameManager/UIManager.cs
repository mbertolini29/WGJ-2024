using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Space]
    public UnityEvent<int> OnUpdatePaddle1Score;
    public UnityEvent<int> OnUpdatePaddle2Score;
    [Space]
    [SerializeField] GameObject gameOverScreen;
    [Space]
    [SerializeField] TMP_Text paddle1ScoreText;
    [SerializeField] TMP_Text paddle2ScoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //
        Time.timeScale = 1;
    }

    public void UpdatePaddle1Score(int paddleScore)
    {
        paddle1ScoreText.text = paddleScore.ToString();
    }

    public void UpdatePaddle2Score(int paddleScore)
    {
        paddle2ScoreText.text = paddleScore.ToString();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

  
}
