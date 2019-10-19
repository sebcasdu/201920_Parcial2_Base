using AI;
using UnityEngine;
public class GetNearestTarget : Node
{
    GameController GC;
    PlayerController[] jugadores;
    GameObject nearestTarget;
    public override void Execute()
    {
        GetTarget();
    }
    public GameObject GetTarget()
    {
        
        jugadores = FindObjectsOfType<PlayerController>();
        float nearest = 100000;
        float distancia;
       
        
        for (int i=0; i< jugadores.Length;i++)
        {

            distancia = Vector3.Distance(gameObject.transform.position, jugadores[i].gameObject.transform.position);

            
            if (distancia < nearest && jugadores[i]!=gameObject.GetComponent<PlayerController>())
            {
               
                
                nearest = Vector3.Distance(gameObject.transform.position, jugadores[i].transform.position);
                nearestTarget = jugadores[i].gameObject;
                
            }
        }
       
        return nearestTarget;
    }
}