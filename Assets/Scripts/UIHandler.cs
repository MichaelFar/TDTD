using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas failScreenUI;
    public Canvas victoryScreenUI;
    public Canvas pauseScreenUI;
    public GameObject trayUI;
    public GameObject startWaveButton;
    public GameObject waveText;

   // public GameObject UITrayTarget;
    public GameObject UITrayOrigin;

    private Vector3 UITrayDestinationPosition;

    private bool trayHidden = false;

    float waveTextVisibleDeltaTracker = 0.0f;
    public float timeThatWaveTextIsVisible = 3.0f;
    bool newWaveStarted = false;
    float waveButtonSize;
    void Start()
    {
        waveButtonSize = Mathf.Sqrt(2);
        UITrayDestinationPosition = trayUI.GetComponent<RectTransform>().localPosition;
        trayUI.GetComponent<RectTransform>().localPosition = UITrayOrigin.GetComponent<RectTransform>().localPosition;
        ShowTrayUI();
        //startWaveButton.transform.localScale = waveButtonSize;
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
        //startWaveButton.SetActive(!startWaveButton.activeSelf);
        startWaveButton.transform.DOScale(0.01f, 0.3f);
    }

    public void SetNewWaveStartedBoolToTrue()
    {
        newWaveStarted = true;
    }

    public void ShowWaveText()
    {
        startWaveButton.transform.DOScale(waveButtonSize, 0.3f);
        //waveText.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideTrayUI()
    {
        trayUI.transform.DOLocalMoveX(UITrayOrigin.GetComponent<RectTransform>().localPosition.x, 0.4f);
        trayHidden = true;
    }

    public void ShowTrayUI()
    {
        trayUI.transform.DOLocalMoveX(UITrayDestinationPosition.x, 0.4f);
        trayHidden = false;
    }

    public void ToggleShowTrayUI()
    {
        if(trayHidden)
        {
            ShowTrayUI();
        }
        else
        {
            HideTrayUI();
        }
    }
}
