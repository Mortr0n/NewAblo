using UnityEngine;

public class CombatActor : MonoBehaviour
{
    protected int factionID = 0;
    protected float damage = 1;

    public virtual void InitializeDamage(float amount)
    {
        damage = amount;
    }

    public void SetFactionID(int newID)
    {
        //Debug.Log("Set Faction ID");
        factionID = newID;
    }

    protected virtual void HitReceiver(CombatReceiver target)
    {
        //Debug.Log("Test Hit");
        target.TakeDamage(damage);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Debug.Log("on trigger combat actor ");
        CombatReceiver combatReceiver = other.GetComponent<CombatReceiver>();
        //Debug.Log($"combat receiver {combatReceiver} is trigger? {other.isTrigger}");
        if (combatReceiver != null && !other.isTrigger)
        {
            //Debug.Log($"Inside first if trigger? {other.isTrigger}");
            if (combatReceiver.GetFactionID() != factionID)
            {
                HitReceiver(combatReceiver);
            }
        }
    }
}
