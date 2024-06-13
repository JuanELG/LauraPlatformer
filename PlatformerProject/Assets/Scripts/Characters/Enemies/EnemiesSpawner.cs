using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyLogicPrefab;
    [SerializeField] private GameObject enemyVisualPrefab;
    [SerializeField] private GameObject waypointA;
    [SerializeField] private GameObject waypointB;
    [SerializeField] private List<CharacterData> possibleCharacterData;
    
    private EnemyBase instantiatedEnemy = null;

    private void Start()
    {
        InstantiateNewEnemy();
    }

    private void Update()
    {
        if (instantiatedEnemy == null || !instantiatedEnemy.gameObject.activeInHierarchy)
        {
            InstantiateNewEnemy();
        }
    }

    private void InstantiateNewEnemy()
    {
        instantiatedEnemy = Instantiate(enemyLogicPrefab, gameObject.transform.position, quaternion.identity).GetComponent<EnemyBase>();
        CharacterVisualController visualController = Instantiate(enemyVisualPrefab, instantiatedEnemy.transform).GetComponent<CharacterVisualController>();
        int randomCharacterDataIndex = Random.Range(0, possibleCharacterData.Count);
        CharacterData randomCharacterData = possibleCharacterData[randomCharacterDataIndex];
        
        instantiatedEnemy.SetCharacterData(randomCharacterData, visualController, waypointA, waypointB);
        
    }
}
