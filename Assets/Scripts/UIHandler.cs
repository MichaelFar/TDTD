using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas failScreenUI;
    public Canvas victoryScreenUI;
    public Canvas pauseScreenUI;
    public GameObject startWaveButton;
    public GameObject waveText;
    
    float waveTextVisibleDeltaTracker = 0.0f;
    public float timeThatWaveTextIsVisible = 3.0f;
    bool newWaveStarted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(newWaveStarted)
        {
            waveTextVisibleDeltaTracker += Time.deltaTime;
            if(waveTextVisibleDeltaTracker >= timeThatWaveTextIsVisible)
            {
                waveText.SetActive(false);
                newWaveStarted = false;
            }
        }

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
    public void TogglePauseScreen()
    {
        pauseScreenUI.enabled = !pauseScreenUI.enabled;
        Time.timeScale = pauseScreenUI.enabled ? 0 : 1;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("Restarting level to " + SceneManager.GetActiveScene().name);
    }

    public void ToggleStartWaveButtonVisible()
    {
        startWaveButton.SetActive(!startWaveButton.activeSelf);
    }

    public void SetNewWaveStartedBoolToTrue()
    {
        newWaveStarted = true;
    }

    public void ShowWaveText()
    {
        waveText.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
