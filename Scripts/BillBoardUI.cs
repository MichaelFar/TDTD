using UnityEngine;

public class BillBoardUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera currentCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FaceCamera();
    }
    void FaceCamera()
    {

        transform.forward = currentCamera.transform.forward;
        //transform.rotation = Quaternion.Euler(currentCamera.transform.rotation.x, transform.rotation.y, 0);
        //transform.rotation = Quaternion.Euler(playerTransform.rotation.x, playerTransform.rotation.y, playerTransform.rotation.z);
    }
}
