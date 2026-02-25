using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas failScreenUI;
    public Canvas victoryScreenUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowFailScreen()
    {
        failScreenUI.enabled = true;
    }
    public void ShowSuccessScreen()
    {
        if(failScreenUI.enabled == false)
        {
            victoryScreenUI.enabled = true;
        }
        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
