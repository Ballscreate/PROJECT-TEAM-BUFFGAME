using UnityEngine;
using Mirror;

public class StatePatrul : State
{
    private readonly UnitController _controller;
    private readonly Transform _Tr;
    public StatePatrul(StateMachine stateMachine,UnitController _controller,Transform _Tr) : base(stateMachine) 
    {
        this._controller = _controller;
        this._Tr = _Tr;
    }
    
    public override void Enter()
    {
         
        Debug.Log("Patrul State Enter");
        stateMachine.AddState(new SearchState(stateMachine,_controller,_Tr));
    }
   
    public override void Update()
    {
        stateMachine.SetState<SearchState>();       
    }
    
}
