
using UnityEngine;

public class FleeState: FSMState
{

    public FleeState()
    {
        stateID = FSMStateID.Fleeing;
    }
    
    public override void Reason(Transform player, Transform npc)
    {
        Debug.Log("No reason to change state.");
    }

    public override void Act(Transform player, Transform npc)
    {
        Debug.Log("Tank is fleeing.");
    }
}
