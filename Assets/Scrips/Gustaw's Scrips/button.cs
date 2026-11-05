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
    
    public void loadNextcene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// Load the next scene in the build index
    }
    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);// Load the scene at index 2 in the build index
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
