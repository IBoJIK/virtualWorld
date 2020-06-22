using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EscapeState : State
{
    private float EnemyDistanceRun = 10;
    private Vector3 dirToPlayer;
    private Vector3 newPos;
    private float curTimeout;

    private NavMeshAgent agent;
    private GameObject player;

    public EscapeState(Military character) : base(character)
    {
        agent = character.GetComponent<NavMeshAgent>();
        player = character.GetComponent<Military>().player;
    }

    public override void Tick()
    {
        agent.isStopped = false;
        Escape();
        if (character.GetComponent<Military>().hp >= 80)
        {
            agent.stoppingDistance = 2.5f;
            character.SetState(new FightState(character));
        }
        if (Vector3.Distance(character.transform.position, player.transform.position) > 70)
        {
            character.SetState(new PatrolState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().materials[2].color = new Color(107, 253, 255);
    }

    private void Escape()
    {
        if (Vector3.Distance(character.transform.position, player.transform.position) < EnemyDistanceRun)
        {
            curTimeout = 0;
            agent.stoppingDistance = 0;
            dirToPlayer = character.transform.position - player.transform.position;
            newPos = character.transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
        else
        {
            if (curTimeout > 0.5f)
            {
                curTimeout = 0;
                character.GetComponent<Military>().hp += 1;
            }
            else
            {
                curTimeout += Time.deltaTime;
            }
        }
        
    }
}
