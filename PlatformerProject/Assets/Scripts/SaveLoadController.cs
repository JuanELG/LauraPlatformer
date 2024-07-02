using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    public static SaveLoadController Instance;
    
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

    /// <summary>
    /// Save any specific game data as string
    /// </summary>
    /// <param name="key">save data key</param>
    /// <param name="data">save data as string</param>
    public void SaveData(string key, string data)
    {
        Debug.Log("Saving data: " + key + "/" + data);
        PlayerPrefs.SetString(key, data);
    }
    
    /// <summary>
    /// Save any specific game data as float
    /// </summary>
    /// <param name="key">save data key</param>
    /// <param name="data">save data as float</param>
    public void SaveData(string key, float data)
    {
        Debug.Log("Saving data: " + key + "/" + data);
        PlayerPrefs.SetFloat(key, data);
    }

    public string LoadStringData(string key)
    {
        string loadedData = PlayerPrefs.GetString(key);
        Debug.Log("loading data: " + key + "/" + loadedData);
        return loadedData;
    }
    
    public float LoadFloatData(string key)
    {
        float loadedData = PlayerPrefs.GetFloat(key, -1000000000f);
        Debug.Log("loading data: " + key + "/" + loadedData);
        return loadedData;
    }
}
