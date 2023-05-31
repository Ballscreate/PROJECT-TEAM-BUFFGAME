using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshotEnemy : TastBotLogic
{
    private GameObject _colliderOthers;

    private bool _drawRay;

    private int layerMaskOnlyPlayer = 1 << 3;
    
   
    

    public void Start() 
    {
        TastBotLogicStart();
        layerMaskOnlyPlayer = ~layerMaskOnlyPlayer;
    }
    public void Update() 
    {
        TastBotLogicUpdate();
        
        if(_drawRay == true) DrawRay(); 
    }
    private void  DrawRay()
    {
            RaycastHit2D hit = Physics2D.Raycast(_Tr.position,_colliderOthers.transform.position - _Tr.position,50,layerMaskOnlyPlayer);
            Debug.DrawRay(_Tr.position,_colliderOthers.transform.position - _Tr.position);
 
            if(hit.collider.CompareTag("Player")) 
            {
                    _purposes.Add(_colliderOthers);
                    Purpose = _purposes[0];
            
                    stateMachine.AddState(new StateAggression(stateMachine,Target,_Tr, Purpose.transform,_botScript,MinDistansAttack));
                    stateMachine.SetState<StateAggression>();

                    _drawRay = false;
            }
            
    }
    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _colliderOthers = other.gameObject;
            _drawRay = true;
        }    
    }
    protected override void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _drawRay = false;
            _purposes.Remove(_colliderOthers);
            stateMachine.SetState<StatePatrul>();
        }   
    }

    
}
