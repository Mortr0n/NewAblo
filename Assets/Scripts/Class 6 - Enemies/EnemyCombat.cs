using UnityEngine;

public class EnemyCombat : CombatReceiver
{
    public override void Die()
    {
        base.Die();
        // notify the AI when the combat receiver dies
        GetComponent<BasicAI>().TriggerDeath();
        // grant the player experience


    }
}
