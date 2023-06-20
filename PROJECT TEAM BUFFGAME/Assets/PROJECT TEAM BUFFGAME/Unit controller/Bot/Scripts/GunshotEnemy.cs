using UnityEngine;
using Mirror;
public class GunshotEnemy : TastBotLogic
{

    private bool _drawRay;

    private int layerMaskOnlyPlayer = 1 << 3; // маска Enemy

    [Server]
    public void Start() 
    {
     
        TastBotLogicStart();
        layerMaskOnlyPlayer = ~layerMaskOnlyPlayer;
    }
    [Server]
    public void Update() 
    {
        
        TastBotLogicUpdate();
        
        if(_drawRay == true) DrawRay(); 
    }
    [Server]
    private void  DrawRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(_Tr.position,_purposes[0].transform.position - _Tr.position,50,layerMaskOnlyPlayer);
        Debug.DrawRay(_Tr.position,_purposes[0].transform.position - _Tr.position);
        if(hit != false)
        {
            if(hit.collider.CompareTag("Player")) 
            {
                stateMachine.AddState(new StateAggression(stateMachine,_controller,_Tr,ref _purposes,_botScript,MinDistansAttack));
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
            _purposes.Add(other.gameObject);
            _drawRay = true;
            Debug.Log(other.gameObject.name);
        }    

    }
    [Server]
    protected override void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _purposes.Remove(other.gameObject);
            _drawRay = false;
            stateMachine.SetState<StatePatrul>();
        }   
    }
   
   

    
}