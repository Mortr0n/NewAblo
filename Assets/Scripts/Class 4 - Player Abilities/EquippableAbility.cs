using UnityEngine;

public class EquippableAbility : ClassSkill
{
    [SerializeField] protected GameObject spawnablePrefab;
    [SerializeField] protected float attackRange = 1.5f;

    protected CombatReceiver targetedReceiver;
    protected PlayerController myPlayer;

    public virtual void RunAbilityClicked(PlayerController player)
    {
        myPlayer = player;
        targetedReceiver = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            player.Movement().MoveToLocation(hit.point);

            if(hit.collider.gameObject.GetComponent<Clickable>())
            {
                Debug.Log("Clickable clicked");
                targetedReceiver = hit.collider.gameObject.GetComponent<CombatReceiver>();
            }
        }
    }

    protected virtual void SpawnEquippedAttack(Vector3 location)
    {
        GameObject newAttack = Instantiate(spawnablePrefab, location, Quaternion.identity);
        //Debug.Log($"faction: {myPlayer.GetFactionID()}");
        newAttack.GetComponent<CombatActor>().SetFactionID(myPlayer.GetFactionID());
    }

    public virtual void CancelAbility()
    {
        targetedReceiver = null;
    }

    protected virtual void Update()
    {
        if (targetedReceiver != null)   RunTargetAttack();
    }

    protected virtual void RunTargetAttack()
    {
        //Debug.Log("Run Target Attack");
        if (Vector3.Distance(myPlayer.transform.position, targetedReceiver.transform.position) <= attackRange)
        {
            myPlayer.Movement().MoveToLocation(myPlayer.transform.position);

            Vector3 lookPos = new Vector3(targetedReceiver.transform.position.x, myPlayer.transform.position.y, targetedReceiver.transform.position.z);
            myPlayer.transform.LookAt(lookPos);

            SpawnEquippedAttack(myPlayer.transform.position + myPlayer.transform.forward);
            myPlayer.GetAnimator().TriggerAttack();


            targetedReceiver = null;
        }
        else
        {
            myPlayer.Movement().MoveToLocation(targetedReceiver.transform.position);
        }
    }
}
