using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button goToMainMenuButton;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        restartGameButton.onClick.AddListener(RestartGame);
        goToMainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void OnDisable()
    {
        restartGameButton.onClick.RemoveAllListeners();
        goToMainMenuButton.onClick.RemoveAllListeners();
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneNames.GAMEPLAY_SCENE_NAME);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU_SCENE_NAME);
    }
}
