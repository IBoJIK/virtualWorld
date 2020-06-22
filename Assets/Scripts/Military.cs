using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Military : MonoBehaviour
{
    private State currentState;

    public GameObject player;
    public NavMeshAgent agent;
    public Transform[] point;
    public int hp = 100;
    public GameObject electricity;


    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        SetState(new PatrolState(this));
        electricity.GetComponent<ParticleSystem>().Stop();
        electricity.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (hp < 100)
        {
            player.GetComponent<Shoot>().isFight = true;
        }
        currentState.Tick();
    }

    public void SetState(State state)
    {
        currentState = state;
        gameObject.name = "NPC - " + state.GetType().Name;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public void AddDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
