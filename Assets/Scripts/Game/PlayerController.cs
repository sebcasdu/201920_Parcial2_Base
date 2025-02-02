﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 3F;
    public bool puedemoverse=true;
    protected NavMeshAgent agent { get; set; }
    public delegate void OnTaggedChange(string newTagged);
    public static event OnTaggedChange onTaggedChange;
    string name;

    public bool IsTagged { get;  set; }
   
    public void SwitchRoles()
    {
        IsTagged = !IsTagged;

        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        puedemoverse = false;

        if (gameObject.GetComponent<BehaviourRunner>() != null)
        {
            gameObject.GetComponent<BehaviourRunner>().enabled = false;
        }
        yield return new WaitForSeconds(stopTime);
        puedemoverse = true;
        gameObject.GetComponent<BehaviourRunner>().enabled = true;
        // Restart stuff.
    }

    protected abstract Vector3 GetLocation();

    // Start is called before the first frame update
    private void Start()
    {

        name = gameObject.name;
        agent = GetComponent<NavMeshAgent>();
       
    }
    public void  stopLogic()
    {
        StartCoroutine(StopLogic());
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController col = collision.gameObject.GetComponent<PlayerController>();


        if (IsTagged)
        {
            col.stopLogic();
            IsTagged = false;
            col.IsTagged = true;
           
          
            
            onTaggedChange(name);
           
            
        }
       

    }
}