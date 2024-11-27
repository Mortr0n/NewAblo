using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void Start()
    {
        // finds main controller gets the object it's attached to and then adds the controller.  Very Cool!  Instead of adding to it in the inspector so you could change it out
        Camera.main.gameObject.AddComponent<CameraController>();
        Camera.main.gameObject.GetComponent<CameraController>().SetFollowTarget(gameObject); // run the CameraControllers SetFollowTarget function
    }
}
