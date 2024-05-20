using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private string[] lista;

    public event Action<int> OnScoreChanged;

    [SerializeField] private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        OnScoreChanged?.Invoke(currentScore);

        string currentSceneName = SceneManager.GetActiveScene().name;
        int currentSceneIndex = -1;
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i] == currentSceneName)
            {
                //Este es el indice de la escena actual
                currentSceneIndex = i;
                break;
            }
        }

        if (currentSceneIndex == -1)
        {
            Debug.LogError("NO SE ENCONTRO NINGUNA ESCENA CON ESE NOMBRE");
            return;
        }

        if (currentSceneIndex == lista.Length)
        {
            SceneManager.LoadScene("Creditos");
        }

        SceneManager.LoadScene(lista[currentSceneIndex + 1]);
    }
}