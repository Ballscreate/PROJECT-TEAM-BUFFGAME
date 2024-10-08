using System.Collections.Generic;
using UnityEngine;

public class StatePursue : State
{
    private readonly UnitController _controller;
    private readonly Transform _Tr;
    private readonly List<GameObject> purpose;

    private readonly TastBotLogic bot;
    private float _forvat;
    private readonly float MinDistansAttack;

    public StatePursue(StateMachine stateMachine,UnitController _controller,Transform _Tr, List<GameObject> purpose,TastBotLogic bot,float MinDistansAttack) : base(stateMachine)
     {
        this._controller = _controller;
        this._Tr = _Tr;
        this.purpose = purpose;
        this.bot = bot;
        this.MinDistansAttack = MinDistansAttack;
     }

    public override void Update()
    {
        if(bot._distant <= MinDistansAttack) stateMachine.SetState<StateAggression>();
        else Pursue();
    }
    
    void Pursue()
    {
         _controller.target = purpose[0].transform.position;
         var pos   = purpose[0].transform.position - _Tr.position;
        _forvat  = Mathf.Atan2(pos.x,pos.y) * Mathf.Rad2Deg * -1;
        _Tr.rotation = Quaternion.Euler(0,0,_forvat);
    }
}
