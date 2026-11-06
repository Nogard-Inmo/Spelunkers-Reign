using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();// Quit the application
    }
    
    public void LoadNextcene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// Load the next scene in the build index
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// Load the current scene
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);// Load the scene at index 0 in the build index
    }
}
