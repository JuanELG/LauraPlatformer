using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int playerLifeCounter = 0;

    private void Start()
    {
        playerLifeCounter = GameplayUIController.Instance.GetPlayerLivesCount();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayerDeath(PlayerMovement player)
    {
        player.RespawnPlayer();
        playerLifeCounter--;
        GameplayUIController.Instance.UpdatePlayerLives(playerLifeCounter);
    }
}
