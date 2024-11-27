using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject followTarget;
    Vector3 offsetVector = new Vector3 (7, 9, -5);

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null) Follow();
        
        // below would also work
        //if (followTarget != null) 
        //    Follow();
    }

    public void SetFollowTarget(GameObject target)
    {
        followTarget = target;
    }

    void Follow()
    {
        transform.position = followTarget.transform.position + offsetVector;
        transform.LookAt(followTarget.transform.position);
    }
}
