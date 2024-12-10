using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{


    public GameObject loadingScreen;
    public Slider progressBar;
    public Text progressText;

    public void Strt(string sceneName)
    {
        StartCoroutine(LoadAsync("GamePlay"));
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true); 

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            int temp = (int)(progress * 100f);
            progressBar.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";
            yield return null;
        }
    }





}





