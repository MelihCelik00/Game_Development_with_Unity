using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallController>()!=null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
