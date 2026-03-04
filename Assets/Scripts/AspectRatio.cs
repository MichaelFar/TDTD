using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class AspectRatio : MonoBehaviour
{
    public float targetAspectRatio = 16f / 9f; // The desired aspect ratio, e.g., 16:9
    private Camera _camera;


    void Start()
    {
        _camera = GetComponent<Camera>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //SetCameraAspect();
    }

    

    
        

    
}