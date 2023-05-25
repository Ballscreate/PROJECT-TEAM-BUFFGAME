using UnityEngine;

public class StatePatrul : State
{
    protected readonly Transform Target;

    protected readonly Transform _Tr;

    private float MinDistansTarget;

    private Vector2 SizePatrol;

    public StatePatrul(StateMachine stateMachine,Transform Target,Transform _Tr,Vector2 SizePatrol,float MinDistansTarget) : base(stateMachine) 
    {
        this.Target = Target;
        this._Tr = _Tr;
        this.MinDistansTarget = MinDistansTarget;
        this.SizePatrol = SizePatrol;
    }

    public override void Enter()
    {
        Debug.Log("Patrul State Enter");
    }
    public override void Exit()
    {
        Debug.Log("Patrul State Exit");
    }
    public override void Update()
    {
        if((Target.position - _Tr.position).magnitude <= MinDistansTarget)
       {
            Patrul();
       }
    }
    void Patrul()
    {
        Target.position = new Vector3
        (
            Random.RandomRange(-SizePatrol.x, SizePatrol.x),
            Random.RandomRange(-SizePatrol.y, SizePatrol.y)
        );
    }
}
