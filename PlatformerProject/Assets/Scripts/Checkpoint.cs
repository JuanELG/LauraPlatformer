using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            SaveLoadController.Instance.SaveData("PLAYER_POSITION_X", player.transform.position.x);
            SaveLoadController.Instance.SaveData("PLAYER_POSITION_Y", player.transform.position.y);
        }
    }
}
