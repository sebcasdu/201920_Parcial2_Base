using AI;
using UnityEngine;
public class IsActorTagged : Selector
{

    protected override bool Check()
    {
        if (gameObject.GetComponent<PlayerController>().IsTagged == true)
        {


            return true;
        }
        else { return false; }
       
    }
}