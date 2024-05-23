using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //COMPARE COLLISIONS WITH COMPONENTS
        if (other.TryGetComponent(out PlayerMovement player))
        {
            player.RespawnPlayer();
        }
        
        //COMPARE COLLISIONS WITH TAGS
        /*if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().RespawnPlayer();
        }*/
    }
}
