using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : BasicAI
{
    enum SkeletonState { Wandering, Pursuing, Attacking, Dead }
    SkeletonState aiState = SkeletonState.Wandering;

    // Wander state variables
    [SerializeField] float maxWanderDistance = 6;
    Vector3 startPosition = Vector3.zero;

    private void Start()
    {
        startPosition = transform.position;
        TriggerWandering();
    }
    protected override void RunAI()
    {
        // so far 4 different behaviors for the ai state 
        switch (aiState) 
        {
            case SkeletonState.Wandering:
                // run wandering functionality
                RunWandering();
                break;
            case SkeletonState.Pursuing:
                RunPursuing();
                break;

            case SkeletonState.Attacking:
                RunAttacking();
                break;

            case SkeletonState.Dead:
                // he be ded

                break;
        }        

    }

    #region Wandering
    void TriggerWandering()
    {
        aiState = SkeletonState.Wandering;
        GetNewWanderDestination();
    }

    void RunWandering()
    {
        float x = agent.destination.x;
        float y = transform.position.y;
        float z = agent.destination.z;

        Vector3 checkPosition = new Vector3(x, y, z);

        if (Vector3.Distance(transform.position, checkPosition) < 1)
        {
            GetNewWanderDestination();
        }
    }

    void GetNewWanderDestination()
    {
        float randomX = Random.Range(-maxWanderDistance, maxWanderDistance);
        float randomZ = Random.Range(-maxWanderDistance, maxWanderDistance);
        float x = randomX + startPosition.x;
        float y = startPosition.y;
        float z = randomZ + startPosition.z;

        agent.destination = new Vector3(x, y, z);
    }
    #endregion


    #region Pursuing
    void TriggerPursuing()
    {


    }

    void RunPursuing()
    {

    }

    #endregion


    #region Attacking
    void TriggerAttacking()
    {

    }

    void RunAttacking()
    {

    }

    #endregion


    #region Dead
    public override void TriggerDeath()
    {
        base.TriggerDeath();
    }
    #endregion
}
