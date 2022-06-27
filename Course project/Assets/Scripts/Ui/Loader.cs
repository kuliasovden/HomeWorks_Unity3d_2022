using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScene;
    [SerializeField] private Slider _loadingBar;

    public void LoadScene(int level)
    {
        StartCoroutine(LoadSceneAsynhronously(level));

    }

    private IEnumerator LoadSceneAsynhronously(int level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        _loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            _loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
