using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DemolishModeButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textLabel;

    public string textLabelDefaultText = "Demolish Mode\r\nActive: ";

    public Color activeColor;

    public Color inactiveColor;

    public float timeToInterpolate = 3.0f;

    private float interpolateDirection = 1.0f;

    public UnityEvent Changed_Active_State;

    private bool _is_active = false;

    private bool isActive
    {
        get { return _is_active; }
        set
        {
            _is_active = value;
            if(value)
            {
                GetComponent<UnityEngine.UI.Image>().color = activeColor;
            }
            else
            {
                GetComponent<UnityEngine.UI.Image>().color = inactiveColor;
            }
            Changed_Active_State.Invoke();
        }
    }

    private float deltaTracker = 0.0f;
    void Start()
    {
        GetComponent<UnityEngine.UI.Image>().color = inactiveColor;
        textLabel.text = textLabelDefaultText + "No";
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            deltaTracker += Time.deltaTime * interpolateDirection;
            float delta_ratio = Mathf.Clamp(deltaTracker / timeToInterpolate, 0.0f, 1.0f);
            GetComponent<UnityEngine.UI.Image>().color = Color.Lerp(activeColor, inactiveColor, delta_ratio);

            if (delta_ratio == 1.0f || delta_ratio == 0.0f)
            {
                interpolateDirection *= -1;
                
            }
        }
            
    }
    private void ToggleText()
    {
        textLabel.text = isActive ? textLabelDefaultText + "Yes" : textLabelDefaultText + "No";
    }
    public void ToggleIsActive()
    {
        isActive = !isActive;
        ToggleText();
    }
}
