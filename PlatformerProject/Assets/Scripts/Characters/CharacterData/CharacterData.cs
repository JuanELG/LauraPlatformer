using UnityEngine;

[CreateAssetMenu(menuName = "Create CharacterData", fileName = "[CharacterName]_CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string characterId;
    [SerializeField] private string characterName;
    [SerializeField] private float characterVelocity;

    public float GetCharacterBaseVelocity => characterVelocity;
}
