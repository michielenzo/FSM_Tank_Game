
using UnityEngine;

public class FleeState: FSMState
{

    public FleeState()
    {
        stateID = FSMStateID.Fleeing;
        curRotSpeed = 1.0f;
        curSpeed = 100.0f;
    }
    
    public override void Reason(Transform player, Transform npc)
    {
        //If the npc tank is far enough away from the player tank it will go back to the patrolling state.
        const float fleeingRange = 500f;
        float distanceTowardsPlayer = Vector3.Distance(npc.position, player.position);
        if (!(distanceTowardsPlayer >= fleeingRange)) return;
        npc.GetComponent<NPCTankController>().SetTransition(Transition.LostPlayer);
    }

    public override void Act(Transform player, Transform npc)
    {
        //In fleeing state the tank turns around towards the opposite direction of the player tank.
        //The direction from the npc tank towards the player tank is calculated. 
        //This direction is then inverted and given a magnitude with the fleeingDistance.
        const float fleeingDistance = 300f;
        Quaternion rotation = npc.rotation;
        Vector3 directionTowardsPlayerTank = (player.position - npc.position).normalized;
        Vector3 directionOppositeToPlayerTank = -directionTowardsPlayerTank * fleeingDistance;
        destPos = directionOppositeToPlayerTank;
        
        //This rotates the npc tank towards the direction opposite to the player tank.
        Quaternion targetRotation = Quaternion.LookRotation(destPos);
        rotation = Quaternion.Slerp(rotation, targetRotation, Time.deltaTime * curRotSpeed);
        npc.rotation = rotation;

        //Move Forward
        npc.Translate(Vector3.forward * (Time.deltaTime * curSpeed));
    }
}
