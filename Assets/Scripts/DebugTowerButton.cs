using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class DebugTowerButton : MonoBehaviour, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject towerObject;

    public PlayerInputContainer playerInput;
    

    void Start()
    {
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
        SendTowerToPlayerInput();
    }

}
