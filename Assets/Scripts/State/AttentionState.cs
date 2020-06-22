using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttentionState : State
{
    private Quaternion rot;
    private Vector3 direction;
    private float speed = 3;
    private NavMeshAgent agent;
    private GameObject player;

    public AttentionState(Military character) : base(character)
    {
        agent = character.GetComponent<NavMeshAgent>();
        player = character.GetComponent<Military>().player;
    }

    public override void Tick()
    {
        Attention();
        if (Vector3.Distance(character.transform.position, player.transform.position) > 5)
        {
            agent.isStopped = false;
            character.SetState(new PatrolState(character));
        }
        if(player.GetComponent<Shoot>().isFight)
        {
            character.SetState(new FightState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().materials[2].color = new Color(200, 200, 0);
    }

    private void Attention()
    {
        agent.isStopped = true;
        direction = player.transform.position - character.transform.position;
        rot = Quaternion.LookRotation(direction);
        character.transform.rotation = Quaternion.Lerp(character.transform.rotation, rot, speed * Time.deltaTime);
    }
}
