using TMPro.Examples;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject testSphere;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RunClickMovement();
        }
    }


    void RunClickMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) 
        {
            if (hit.point != Vector3.zero) // zero value means something went wrong getting the hit.point because it will return (0, 0, 0)
            {
                //testSphere.transform.position = hit.point; // originally to move the sphere after the clicker before we added in the navmesh agent
                agent.destination = hit.point;
            }
        }

    }



}
