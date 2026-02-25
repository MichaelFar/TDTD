using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class DebugTowerButton : MonoBehaviour, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject towerObject;

    public PlayerInputContainer playerInput;

    private int _current_value;
    public int currentValue
    {
        get { return _current_value; }
        set
        {
            _current_value = value;
            textLabel.text = labelText + _current_value.ToString();
        }
    }
    public string labelText;

    public TextMeshProUGUI textLabel;

    public float valueOfTower;
    void Start()
    {
        valueOfTower = towerObject.GetComponent<Tower>().towerValue;
        currentValue = (int)valueOfTower;
        //GetComponent<Button>().MouseDown.AddListener(SendTowerToPlayerInput);
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }

    public void SendTowerToPlayerInput()
    {
        playerInput.SetCurrentTowerObject(towerObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //is_Touched = false;
        if(playerInput.playerMM.CheckIfCanPurchase(valueOfTower))
        {
            SendTowerToPlayerInput();
        }
        
    }

}
