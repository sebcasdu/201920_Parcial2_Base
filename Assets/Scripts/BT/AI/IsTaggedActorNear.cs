using AI;
using UnityEngine;
public class IsTaggedActorNear : Selector
{
    [SerializeField] float  distanciaDeteccion;
    PlayerController[] jugadores;

    PlayerController TaggedPlayer;
    protected override bool Check()
    {
        jugadores = FindObjectsOfType<PlayerController>();
        
        float distancia;


        for (int i = 0; i < jugadores.Length; i++)
        {
            if(jugadores[i].IsTagged==true)
            {
                TaggedPlayer = jugadores[i];
            }
        }
        
        distancia = Vector3.Distance(gameObject.transform.position, TaggedPlayer.gameObject.transform.position);
       
        if(distancia<distanciaDeteccion)
        {
            return true;
        }else
        {
            return false;
        }
    }
    public override void Execute()
    {
        if(Check())
        {
            children[0].Execute();


        }else
        {
            children[1].Execute();


        }
    }
}