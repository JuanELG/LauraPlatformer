using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController Instance;
    
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private List<Image> playerLivesImageList;

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

    public int GetPlayerLivesCount()
    {
        return playerLivesImageList.Count;
    }

    public void UpdatePlayerLives(int currentLivesCount)
    {
        for (int i = 0; i < playerLivesImageList.Count; i++)
        {
            if (i >= currentLivesCount)
            {
                //SET AS INACTIVE THE PLAYER LIVE IMAGE
                //playerLivesImageList[i].gameObject.SetActive(false);
                //HIDE THE PLAYER LIVE IMAGE ALONG A TIME
                StartCoroutine(LiveImageFadeOutCoroutine(playerLivesImageList[i]));
            }
        }
        
        if (currentLivesCount == 0)
        {
            gameOverController.ShowGameOver();
        }
    }
    
    private IEnumerator LiveImageFadeOutCoroutine(Image imageTarget)
    {
        float fadeDuration = 1.5f;
        float currentTime = 0f;
        float initialFIll = imageTarget.fillAmount;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float newFillAmount = Mathf.Lerp(initialFIll, 0f, currentTime / fadeDuration);
            imageTarget.fillAmount = newFillAmount;
            yield return null;
        }
        imageTarget.fillAmount = 0f;
    }
}
