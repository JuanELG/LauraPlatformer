using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button goToSettingButton;
    [SerializeField] private Button goToMainMenuButton;
    [SerializeField] private Button playGameButton;

    [SerializeField] private GameObject settingCanvasGameObject;
    [SerializeField] private GameObject mainMenuCanvasGameObject;

    private void Awake()
    {
        GoToMainMenu();
    }

    private void Start()
    {
        goToSettingButton.onClick.AddListener(GoToSettingsMenu);
        goToMainMenuButton.onClick.AddListener(GoToMainMenu);
        playGameButton.onClick.AddListener(PlayGame);
    }

    private void GoToSettingsMenu()
    {
        mainMenuCanvasGameObject.SetActive(false);
        settingCanvasGameObject.SetActive(true);
    }

    private void GoToMainMenu()
    {
        mainMenuCanvasGameObject.SetActive(true);
        settingCanvasGameObject.SetActive(false);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(SceneNames.GAMEPLAY_SCENE_NAME);
    }
}
