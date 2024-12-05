using UnityEngine;
using UnityEngine.AI;  // for navmesh agents and moving using nav mesh agents

[RequireComponent(typeof(NavMeshAgent))]  // forces component on item as soon as script is applied to item
public class BasicAI : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected bool alive = true;
    protected int factionID = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();  // start would normall work in the vast majority of cases but we need awake to be absoulutely sure it's available when it's instantiated or called
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(alive) RunAI();
    }

    protected virtual void RunAI()
    {   

    
    }

    public virtual void SetFactionID(int newID)
    {
        factionID = newID;
        GetComponent<CombatReceiver>().SetFactionID(newID);
    }

    public virtual void TriggerDeath()
    {
        if (!alive) return;
        alive = false;

        if (GetComponent<EnemyAnimator>() != null)
            GetComponent<EnemyAnimator>().TriggerDeath();

        // doing all the disable so that we can keep a dead body, but it won't cause problems or be using resources.
        Collider[] attachedColliders = GetComponents<Collider>();  
        foreach(Collider c in attachedColliders)
        {
            c.enabled = false; // disable colliders so that they no longer interact with things like the fireball
        }

        agent.enabled = false;  // stops it from interacting with everything in the game
    }
}
