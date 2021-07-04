using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public void Quit()
    {
        Debug.Log("APPLICATION QUIT!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}