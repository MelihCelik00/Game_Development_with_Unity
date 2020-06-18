using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartScene()
    {
        Debug.Log("Restarting SCENE!");
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
        Debug.Log("Entered LoadScene method!");
        SceneManager.LoadScene(buildIndex);
    }

    private int GetActiveSceneIndex()
    {
        Debug.Log("Get Active Build Index!");
        return SceneManager.GetActiveScene().buildIndex;
    }
    
}
