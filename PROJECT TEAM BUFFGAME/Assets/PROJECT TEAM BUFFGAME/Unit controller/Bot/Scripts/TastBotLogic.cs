using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TastBotLogic : MonoBehaviour
{
    [Header("State")]
    protected StateMachine stateMachine;

    [Header("Transform/Point")]
    protected Transform _Tr;

    [Header("GameObject")]
    protected List<GameObject> _purposes = new();
    protected GameObject Purpose{get;set;}

    [Header("Other Variables")]
    [SerializeField] protected float MinDistansTarget;
    [SerializeField] protected float MinDistansAttack;
    [SerializeField] protected Vector2 SizePatrol;

    public float _distant;

    protected TastBotLogic _botScript;
    protected UnitController _controller;

    protected void TastBotLogicStart()
    {
        _botScript = this;
        _Tr = transform;
        _controller = GetComponent<UnitController>();

        stateMachine = new StateMachine();
        stateMachine.AddState(new StatePatrul(stateMachine,_controller,_Tr));
        stateMachine.SetState<StatePatrul>();
    }

   protected void TastBotLogicUpdate()
    {
        if(Purpose != null)
        {
            _distant = Vector3.Distance(Purpose.transform.position,_Tr.position);
        }
        stateMachine.Update();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _purposes.Add(other.gameObject);
            Purpose = _purposes[0];
            
            stateMachine.AddState(new StateAggression(stateMachine,_controller,_Tr, Purpose.transform,_botScript,MinDistansAttack));
            stateMachine.SetState<StateAggression>();
        }    
    }
    protected virtual void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
           stateMachine.SetState<StatePatrul>();
        }    
    }
    

}
