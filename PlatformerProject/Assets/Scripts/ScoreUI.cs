using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    /*----------DECLARACIÓN DE VARIABLES--------------------*/
    [SerializeField] private TMP_Text coinText;
    private float miVariable = 0;
    /*-----------------------------------------------------*/

    /*----------FUNCIONES DE UNITY-------------------------*/
    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }
    /*-----------------------------------------------------*/


    /*----------FUNCIONES PROPIAS--------------------------*/
    private void UpdateScoreText(int newScore)
    {
        coinText.text = "Score: " + newScore;
    }
    /*-----------------------------------------------------*/
}