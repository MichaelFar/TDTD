using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using UnityEngine.InputSystem.EnhancedTouch;
public class PlayerInputContainer : MonoBehaviour
{

    public GameObject testTowerPrefab;

    public Touchscreen touchscreen;

    private GameObject selectedTowerObject;

    private enum InputState {PLACEMENTSCREEN};//Handles instances where certain input contexts should be checked, IE we shouldn't place towers on the pause menu

    private InputState currentInputState = InputState.PLACEMENTSCREEN;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
        //UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += get_touch_details;
    }
    void Start()
    {
        
    }

    public void Update()
    {
        ProcessTouchInput();
        
    }

    void ProcessTouchInput()
    {
        foreach (var touch in Touch.activeTouches)
        {
            

            Ray ray_vector = Camera.main.ScreenPointToRay(touch.screenPosition);

            RaycastHit[] ray_hits = Physics.RaycastAll(ray_vector, Mathf.Infinity);//Physics.Raycast(Camera.main.ScreenToWorldPoint(touch.screenPosition),Camera.main.transform.forward,out hit,1000.0f);//Camera.main.ScreenPointToRay(touch.screenPosition);
            foreach (RaycastHit i in ray_hits)
            { 
                if (i.collider.GetComponent<TowerSlot>())
                {
                    TowerSlot this_tower_slot = i.collider.GetComponent<TowerSlot>();
                    if (touch.phase == TouchPhase.Ended)
                    {
                        if(selectedTowerObject != null)
                        {
                            this_tower_slot.InstanceNewTower(selectedTowerObject);
                            selectedTowerObject = null;
                        }
                        
                    }
                }
            //print(hit.collider.gameObject.name);
                Debug.Log($"{touch.touchId}: {i.point},{touch.phase}");
            }

            if (touch.phase == TouchPhase.Ended && selectedTowerObject != null)
            {
                print("Setting selected tower object to null");
                selectedTowerObject = null;
            }

        }
        
    }

    public void SetCurrentTowerObject(GameObject new_tower_object)
    {
        print("Receiving tower " + new_tower_object);
        selectedTowerObject = new_tower_object;
    }
}
