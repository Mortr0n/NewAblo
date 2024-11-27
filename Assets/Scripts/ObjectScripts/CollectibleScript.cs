using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private GameObject player;
    private GameObject gateTrigger;

    void Start()
    {
        //player = GameObject.Find("Player");
        gateTrigger = GameObject.Find("GateTrigger");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorOpen doorOpen = gateTrigger.GetComponent<DoorOpen>();

            doorOpen.IsOpenable = true;
            Destroy(gameObject);
        }
    }
}
