using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private int randPoint;
    private NavMeshAgent agent;
    private Transform[] point;
    private GameObject player;

    public PatrolState(Military character): base(character)
    {
        agent = character.GetComponent<NavMeshAgent>();
        point = character.GetComponent<Military>().point;
        player = character.GetComponent<Military>().player;
    }
    
    public override void Tick()
    {
        Patrol();
        if (Vector3.Distance(character.transform.position, player.transform.position) <= 5)
        {
            character.SetState(new AttentionState(character));
        }
        if (player.GetComponent<Shoot>().isFight && Vector3.Distance(character.transform.position, player.transform.position) <= 50)
        {
            character.SetState(new FightState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().materials[2].color = new Color(0, 200, 0);
    }

    private void Patrol()
    {
        agent.SetDestination(point[randPoint].position);
        if (agent.remainingDistance < 2.5f)
        {
            randPoint = Random.Range(0, point.Length);
        }
    }
}
