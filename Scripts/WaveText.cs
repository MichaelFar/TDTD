using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    

    private int _current_wave; // field

    public int initialValue = 1;

    public int currentValue
    {
        get { return _current_wave; }
        set { _current_wave = value;
            textElement.text = labelText + _current_wave.ToString();
        }
    }
    public string labelText;

    public TextMeshProUGUI textElement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCurrentWave(initialValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentWave(int new_value)
    {
        currentValue = new_value;
    }

    public void IndicateFinalWave()
    {
        textElement.text = "Final Wave";
    }
    public void IndicateWaveCompleted()
    {
        textElement.text = "Wave Completed";
    }
}
