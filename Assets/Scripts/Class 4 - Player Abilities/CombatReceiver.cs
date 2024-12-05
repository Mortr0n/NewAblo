using UnityEngine;

public class CombatReceiver : Clickable
{
    protected int factionID = 0; //splitting combat system into factions to allow this to be used for all

    [SerializeField] protected float maxHP = 35;
    protected float currentHP;
    protected bool alive = true;

    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    public virtual void Die() 
    {
        alive = false;
    }

    public void SetFactionID(int newID)
    {
        factionID = newID;
    } 

    public int GetFactionID() { return factionID; }

    public virtual void TakeDamage(float amount)
    {
        if (!alive) { return; }

        currentHP -= amount;
        if(currentHP <= 0) Die();
    }

    public virtual void Revive()
    {
        
    }


}
