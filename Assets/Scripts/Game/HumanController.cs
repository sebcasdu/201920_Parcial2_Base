using UnityEngine;


public class HumanController : PlayerController
{
    [SerializeField]
    private LayerMask walkable;

    
    protected override Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, walkable);
        return hit.point ;
    }
    public void Update()
    {
        if(puedemoverse==true)
        { 
           if (Input.GetButtonDown("Fire1"))
           {

            GoToLocation(GetLocation());
           }
        }
    }
}