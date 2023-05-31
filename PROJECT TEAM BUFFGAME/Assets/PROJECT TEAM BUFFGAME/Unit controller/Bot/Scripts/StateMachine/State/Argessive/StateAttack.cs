using UnityEngine;

public class StateAttack : State
{
      private readonly Transform _Tr;
      private readonly Transform purpose;

      private readonly TastBotLogic bot;
      
      private float _forvat;
      private readonly float MinDistansAttack;

   
      
     public StateAttack(StateMachine stateMachine,Transform _Tr, Transform purpose,TastBotLogic bot,float MinDistansAttack) : base(stateMachine)
     {
        this._Tr = _Tr;
        this.purpose = purpose;
        this.bot = bot;
        this.MinDistansAttack = MinDistansAttack;
     }
    public override void Update()
    {
        if(bot._distant > MinDistansAttack) stateMachine.SetState<StateAggression>();
        else Attacka();
    }

    void Attacka()
    {
         var pos = purpose.position - _Tr.position;
        _forvat  = Mathf.Atan2(pos.x,pos.y) * Mathf.Rad2Deg * -1;
        _Tr.rotation = Quaternion.Euler(0,0,_forvat);
        Debug.Log("Attack");
    }
}
