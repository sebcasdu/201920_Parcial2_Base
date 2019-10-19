using AI;
using UnityEngine;
public class FollowTarget : Node
{
    public override void Execute()
    {

        gameObject.GetComponent<AIController>().GoToLocation(gameObject.GetComponent<GetNearestTarget>().GetTarget().transform.position);
       
    }
    
}