using UnityEngine;

public class StateAggression : State
{
    private readonly Transform Target;
    private readonly Transform _Tr;
    private readonly Transform purpose;
    
    private readonly float MinDistansAttack;
    private readonly TastBotLogic bot;

    public StateAggression(StateMachine stateMachine,Transform Target,Transform _Tr, Transform purpose,TastBotLogic bot,float MinDistansAttack) : base(stateMachine)
    {
        this.Target = Target;
        this._Tr = _Tr;
        this.purpose = purpose;
        this.bot = bot;
        this.MinDistansAttack = MinDistansAttack;
    }

    public override void Enter()
    {
        stateMachine.AddState(new StatePursue(stateMachine,Target,_Tr,purpose.transform,bot,MinDistansAttack));
        stateMachine.AddState(new StateAttack(stateMachine,_Tr,purpose.transform,bot,MinDistansAttack));
        Debug.Log("State Aggression Enter");
    }
    public override void Update() => Aggression();
  
    void Aggression()
    {   
        if(bot._distant <= MinDistansAttack) stateMachine.SetState<StateAttack>();
        else stateMachine.SetState<StatePursue>();
    }
}
