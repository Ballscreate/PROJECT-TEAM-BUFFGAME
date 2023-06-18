using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class GunshotEnemy : TastBotLogic
{
    private GameObject _colliderOthers;

    private bool _drawRay;

    private int layerMaskOnlyPlayer = 1 << 3; // маска Enemy
    [Server]
    public void Start() 
    {
        if(!isServer) return;
        TastBotLogicStart();
        layerMaskOnlyPlayer = ~layerMaskOnlyPlayer;
    }
    [Server]
    public void Update() 
    {
        if(!isServer) return;
        TastBotLogicUpdate();
        
        if(_drawRay == true) DrawRay(); 
    }
    protected override void RemovePurpose()
    {
       
       stateMachine.SetState<StateAggression>();
    }
    [Server]
    private void  DrawRay()
    {
            RaycastHit2D hit = Physics2D.Raycast(_Tr.position,_colliderOthers.transform.position - _Tr.position,50,layerMaskOnlyPlayer);
            Debug.DrawRay(_Tr.position,_colliderOthers.transform.position - _Tr.position);
        if(hit != false)
        {
            if(hit.collider.CompareTag("Player")) 
            {
                    _purposes.Add(_colliderOthers);
                
                     _purposes[0].GetComponent<UnitPlayerDeath>().OnDeath += RemovePurpose;
            
                    stateMachine.AddState(new StateAggression(stateMachine,_controller,_Tr, _purposes[0].transform,_botScript,MinDistansAttack));
                    stateMachine.SetState<StateAggression>();

                    _drawRay = false;
            }
            else return;
        }
            

    }
    
    [Server]
    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _colliderOthers = other.gameObject;
            _drawRay = true;
        }    
    }
    [Server]
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