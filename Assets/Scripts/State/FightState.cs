using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FightState : State
{
    private Quaternion rot;
    private Vector3 direction;
    private float speed = 2;

    private NavMeshAgent agent;
    private GameObject player;
    private GameObject elect;

    float timer = 0;

    public FightState(Military character) : base(character)
    {
        agent = character.GetComponent<NavMeshAgent>();
        player = character.GetComponent<Military>().player;
        elect = character.GetComponent<Military>().electricity;
    }

    public override void Tick()
    {
        Fight();
        if (Vector3.Distance(character.transform.position, player.transform.position) > 70)
        {
            character.SetState(new PatrolState(character));
        }
        if(character.GetComponent<Military>().hp < 50)
        {
            character.SetState(new EscapeState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().materials[2].color = new Color(200, 0, 0);
    }

    private void Fight()
    {
        agent.stoppingDistance = 2.5f;
        agent.SetDestination(player.transform.position);

        if (agent.isStopped)
        {
            direction = player.transform.position - character.transform.position;
            rot = Quaternion.LookRotation(direction);
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation, rot, speed * Time.deltaTime);
        }
        if (timer < 4)
        {
            elect.GetComponent<ParticleSystem>().Stop();
            elect.GetComponent<BoxCollider>().enabled = false;
        }
        if (Vector3.Distance(character.transform.position, player.transform.position) <= 2.5f)
        {
            agent.isStopped = true;
            if (timer <= 0)
            {
                elect.GetComponent<BoxCollider>().enabled = true;
                elect.GetComponent<ParticleSystem>().Play();
                timer = 5;
            }
        }
        else
        {
            agent.isStopped = false;
        }
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
