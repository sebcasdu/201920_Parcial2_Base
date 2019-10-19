using AI;
using UnityEngine;
public class IsActorTagged : SelectWithOption
{
     
    public override bool Check()
    {
            if (gameObject.GetComponent<PlayerController>().IsTagged == true)
            {

            
                return true;

            }
            else {
           
                return false; }
       
    }
    public override void Execute()
    {
       
        base.Execute();
    }
 
}