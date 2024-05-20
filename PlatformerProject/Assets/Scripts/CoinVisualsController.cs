using UnityEngine;

public class CoinVisualsController : MonoBehaviour
{
    public ScoreManager _scoreManager = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Increse score
        _scoreManager.IncreaseScore(10);
        gameObject.SetActive(false);
    }
}
