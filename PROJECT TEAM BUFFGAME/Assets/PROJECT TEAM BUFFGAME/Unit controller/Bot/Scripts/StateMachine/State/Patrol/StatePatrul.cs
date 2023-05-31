using UnityEngine;

public class StatePatrul : State
{
    private readonly Transform Target;
    private readonly Transform _Tr;
    public StatePatrul(StateMachine stateMachine,Transform Target,Transform _Tr) : base(stateMachine) 
    {
        this.Target = Target;
        this._Tr = _Tr;
    }
    public override void Enter()
    {
        Debug.Log("Patrul State Enter");
        stateMachine.AddState(new SearchState(stateMachine,Target,_Tr));
    }
    public override void Update()
    {
        stateMachine.SetState<SearchState>();       
    }
    
}
