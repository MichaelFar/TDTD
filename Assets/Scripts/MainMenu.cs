using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas mainMenuPanel;
    public Canvas levelSelectPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLevelSelect()
    {
        mainMenuPanel.enabled = !mainMenuPanel.enabled;
        levelSelectPanel.enabled = !levelSelectPanel.enabled;
    }
    public void GoToLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
