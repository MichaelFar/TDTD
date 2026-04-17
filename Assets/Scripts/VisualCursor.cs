using UnityEngine;
using UnityEngine.UI;

public class VisualCursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image cursorImage;
    public Color debug_color;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAndSetTexture(Image new_image)
    {
        cursorImage.enabled = true;
       // cursorImage.
        cursorImage.color = new_image.color;
    }
    public void HideTexture()
    {
        cursorImage.enabled = false;
    }
}
