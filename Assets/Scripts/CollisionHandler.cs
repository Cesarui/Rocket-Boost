using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandAlert : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You are colliding with a friendly object");
                break;
            case "Fuel":
                Debug.Log("You got some fuel");
                break;
            case "Finish":
                Debug.Log("You have reacher the finished station");
                break;
            default:
                ReloadLevel();
                break;
        }

        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}
