using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    
    public GameObject coinPrefab;
    public GameObject coinsContainer;
    private float timer;
    
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            timer = 0;
            Vector3 position = new Vector3(Random.Range(-30, 30), 0, 0);
            GameObject instantiatedPrefab = Instantiate(coinPrefab, position, Quaternion.identity, coinsContainer.transform);
            CoinVisualsController coinVisual = instantiatedPrefab.GetComponentInChildren<CoinVisualsController>();
            coinVisual._scoreManager = scoreManager;
        }
    }
}