using UnityEngine;

public class EvadeState : FSMState
{
    public const float evadingStateTriggerDistance = 75;
    private const float _evadingTargetDistance = 135;

    public EvadeState()
    {
        stateID = FSMStateID.Evade;
        curRotSpeed = 1.0f;
        curSpeed = 100.0f;
    }

    public override void Reason(Transform player, Transform npc)
    {
        //Transition towards the Patrol state once evading is done.
        if (Vector3.Distance(player.transform.position, npc.transform.position) >= _evadingTargetDistance)
        {
            npc.GetComponent<NPCTankController>().SetTransition(Transition.OutOfEvadingRange);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //Move Backwards
        npc.Translate(Vector3.back * (Time.deltaTime * curSpeed));
    }
}
