using UnityEngine;
using System.Collections.Generic;

public class StateAggression : State
{
    private readonly UnitController _controller;
    private readonly Transform _Tr;
    private readonly List<GameObject> purpose;
    
    private readonly float MinDistansAttack;
    private readonly TastBotLogic bot;
   
    public StateAggression(StateMachine stateMachine,UnitController _controller,Transform _Tr,ref List<GameObject> purpose,TastBotLogic bot,float MinDistansAttack) : base(stateMachine)
    {
        this._controller = _controller;
        this._Tr = _Tr;
        this.purpose = purpose;
        this.bot = bot;
        this.MinDistansAttack = MinDistansAttack;
    }
   
    public override void Enter()
    {
        stateMachine.AddState(new StatePursue(stateMachine,_controller,_Tr,purpose,bot,MinDistansAttack));
        stateMachine.AddState(new StateAttack(stateMachine,_Tr,purpose,bot,MinDistansAttack));
        base.Enter();
    }

    public override void Update()
    {
        
        if(purpose.Count > 0)
        {
            Aggression();
        }
    }
    
    void Aggression()
    {   
        if(bot._distant <= MinDistansAttack) stateMachine.SetState<StateAttack>();
        else stateMachine.SetState<StatePursue>();
    }
}
