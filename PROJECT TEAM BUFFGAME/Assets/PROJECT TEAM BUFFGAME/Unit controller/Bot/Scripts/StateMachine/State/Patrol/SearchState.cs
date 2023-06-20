using UnityEngine; 

public class SearchState : State
{
    private readonly UnitController _controller;
    private readonly Transform _Tr;
    
    private Vector3 pointPosition;
    


    public SearchState(StateMachine stateMachine,UnitController _controller,Transform _Tr) : base(stateMachine) 
    {
        this._controller = _controller;
        this._Tr = _Tr;
    }
    
    
    public override void Enter()
    {
         pointPosition  = GlobalPatrolPoints.patrolPoints[Random.Range(0,GlobalPatrolPoints.patrolPoints.Count)];
         base.Enter();
    }    
    
    
    public override void Update()
    {
        Search();
    }
   
    private void Search()
    {
        if (_Tr.position.x == pointPosition.x || _Tr.position.y == pointPosition.y)
        {
            pointPosition  = GlobalPatrolPoints.patrolPoints[Random.Range(0,GlobalPatrolPoints.patrolPoints.Count)];
        }
        else
        { 
            _controller.target = pointPosition;
        }
        
    }
}
