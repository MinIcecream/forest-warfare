using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }    
    public void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.ExecutePhysics();
        }
    }
}
public interface IState
{
    void Enter();
    void Execute();
    void ExecutePhysics();
    void Exit();
}
public interface StateManaged
{
    void RequestState(IState requestedState);
}

