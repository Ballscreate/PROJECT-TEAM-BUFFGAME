using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    private readonly Transform Target;
    private readonly Transform _Tr;
    
    private Vector3 pointPosition;
    


    public SearchState(StateMachine stateMachine,Transform Target,Transform _Tr) : base(stateMachine) 
    {
        this.Target = Target;
        this._Tr = _Tr;
    }
    public override void Enter()
    {
         pointPosition  = GlobalPatrolPoints.patrolPoints[Random.Range(0,GlobalPatrolPoints.patrolPoints.Count)];
         Debug.Log("SearchState Enter");
    }    
    public override void Update() => Search();
    
    private void Search()
    {
        if (_Tr.position.x == pointPosition.x || _Tr.position.y == pointPosition.y)
        {
            pointPosition  = GlobalPatrolPoints.patrolPoints[Random.Range(0,GlobalPatrolPoints.patrolPoints.Count)];
        }
        else
        {
            Target.position = pointPosition;
        }
    }
}
