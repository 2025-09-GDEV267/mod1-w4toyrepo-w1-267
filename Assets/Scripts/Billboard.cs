using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        // Make the object face the camera
        transform.LookAt(Camera.main.transform);

        // Optional: keep it upright
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
