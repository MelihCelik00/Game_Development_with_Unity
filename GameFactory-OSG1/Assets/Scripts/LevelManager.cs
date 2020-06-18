using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartScene()
    {
        StartCoroutine(RestartSceneCoroutine());
    }

    private IEnumerator RestartSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        LoadScene(GetActiveSceneIndex());
    }

    public void NextLevel()
    {
        LoadScene(GetActiveSceneIndex()+1);
    }

    private void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    private int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
}
