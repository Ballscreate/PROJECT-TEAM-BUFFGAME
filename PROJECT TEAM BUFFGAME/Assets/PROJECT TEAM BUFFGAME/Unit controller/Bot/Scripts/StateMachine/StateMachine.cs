using System;
using System.Collections.Generic;
using Mirror;

public class StateMachine 
{
    private State StateCurrent{get;set;}

    private Dictionary<Type, State> _states = new Dictionary<Type, State>();

    public void AddState(State state)
    {
        if(!_states.ContainsKey(state.GetType()))     
        {   
        _states.Add(state.GetType(),state);
        }
    }
    public void SetState<T>() where T: State
    {
        var type = typeof(T);

        if( StateCurrent != null && StateCurrent.GetType() == type)
        {
            return;
        }
        if(_states.TryGetValue(type,out var newState))
        {
            StateCurrent?.Exit();
            StateCurrent = newState;

            StateCurrent.Enter();
        }
    }
  
    public void Update()
    {
        StateCurrent?.Update();
    }
}
