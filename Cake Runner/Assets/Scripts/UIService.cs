using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI cakeText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private TextMeshProUGUI finalCakeAmount;
    [SerializeField] private GameObject endGamePanel;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainButtonClicked);
    }

    private void OnPlayAgainButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateTimer(float timer)
    {
        timerText.text = $"{Mathf.CeilToInt(timer)}s";
    }

    public void UpdateCakeAmount(int amount)
    {
        cakeText.text = amount.ToString() ;
    }

    public void OpenEndGamePopup()
    {
        endGamePanel.SetActive(true);
        finalCakeAmount.text = cakeText.text;
        Time.timeScale = 0.01f;
    }
}
