using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Military character;

    public abstract void Tick();

    public virtual void OnStateEnter() { }

    public State(Military character)
    {
        this.character = character;
    }
}
