using AI;
using UnityEngine;
public class FleeFromTaggedActor : Node
{
    PlayerController[] jugadores;
    PlayerController TaggedPlayer;
    public override void Execute()
    {
        jugadores = FindObjectsOfType<PlayerController>();

        for (int i = 0; i < jugadores.Length; i++)
        {
            if (jugadores[i].IsTagged == true)
            {
                TaggedPlayer = jugadores[i];
            }
        }

        Vector3 fleeLocation = gameObject.transform.position+ new Vector3(Random.Range(-20,20),0, Random.Range(-20, 20));

        gameObject.GetComponent<PlayerController>().GoToLocation(fleeLocation);
    }
}