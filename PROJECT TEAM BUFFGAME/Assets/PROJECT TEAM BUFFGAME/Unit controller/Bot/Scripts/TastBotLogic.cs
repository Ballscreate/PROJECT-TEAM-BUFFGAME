using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TastBotLogic : NetworkBehaviour
{
    [Header("State")]
    protected StateMachine stateMachine;


    [Header("Transform/Point")]
    protected Transform _Tr;


    [Header("GameObject")]
    protected List<GameObject> _purposes = new();

    
    [Header("Other Variables")]
    [SerializeField] protected float MinDistansTarget;
    [SerializeField] protected float MinDistansAttack;
    [SerializeField] protected Vector2 SizePatrol;
    public float _distant;
    protected TastBotLogic _botScript;
    protected UnitController _controller;


    [Server]
    protected void TastBotLogicStart()
    {
        _botScript = this;
        _Tr = transform;
        _controller = GetComponent<UnitController>();

        stateMachine = new StateMachine();
        stateMachine.AddState(new StatePatrul(stateMachine,_controller,_Tr));
        stateMachine.SetState<StatePatrul>();
    }
    [Server]
   protected void TastBotLogicUpdate()
    {
        if(_purposes.Count > 0)
        {
            _distant = Vector3.Distance(_purposes[0].transform.position,_Tr.position);
        }
        stateMachine.Update();
    }
    [Server]
    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _purposes.Add(other.gameObject);
            stateMachine.AddState(new StateAggression(stateMachine,_controller,_Tr, ref _purposes,_botScript,MinDistansAttack));
            stateMachine.SetState<StateAggression>();
        }    
    }
    [Server]
    protected virtual void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _purposes.Remove(other.gameObject);
           stateMachine.SetState<StatePatrul>();
        }    
    }
    

}