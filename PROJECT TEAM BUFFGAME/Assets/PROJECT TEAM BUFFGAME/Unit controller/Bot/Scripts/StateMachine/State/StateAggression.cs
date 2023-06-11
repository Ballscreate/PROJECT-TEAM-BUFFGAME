using System;
using UnityEngine;

public class StateAggression : State
{
    protected readonly Transform Target;
    protected readonly Transform _Tr;
    protected readonly Transform purpose;

    private Transform forward;

    private float _forvat;
    public StateAggression(StateMachine stateMachine,Transform Target,Transform _Tr, Transform purpose) : base(stateMachine)
    {
        this.Target = Target;
        this._Tr = _Tr;
        this.purpose = purpose;
    }

    public override void Enter()
    {
        Debug.Log("State Aggression Enter");
    }
    public override void Exit()
    {
        Debug.Log("State Aggression Exit");
    }
    public override void Update()
    {
        Aggression();
    }
    void Aggression()
    {
        Target.position = purpose.position +  new Vector3(0,5,0);
        var pos   = purpose.position - _Tr.position;
        _forvat  = Mathf.Atan2(pos.x,pos.y) * Mathf.Rad2Deg * -1;
        _Tr.rotation = Quaternion.Euler(0,0,_forvat);
        if((Target.position - _Tr.position).magnitude < 1)
        {
            Debug.Log("Attack");
        }
    }
}
