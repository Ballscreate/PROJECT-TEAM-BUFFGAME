using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastBotLogic : MonoBehaviour
{
    [Space]
    [Header("State")]
    private StateMachine stateMachine;

    [Space]
    [SerializeField]private Transform Target;
    private Transform _Tr;

    [Space]
    private List<GameObject> _purposes = new();
    private GameObject purpose{get;set;}


    [SerializeField] private float MinDistansTarget;

    [SerializeField] private Vector2 SizePatrol;
    private void Start()
    {
        _Tr = transform;
        stateMachine = new StateMachine();

        stateMachine.AddState(new StatePatrul(stateMachine,Target,_Tr,SizePatrol,MinDistansTarget));

        stateMachine.SetState<StatePatrul>();
    }

    void Update()
    {
      stateMachine.Update();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _purposes.Add(other.gameObject);
            purpose = _purposes[0];
            
            stateMachine.AddState(new StateAggression(stateMachine,Target,_Tr, purpose.transform));
            stateMachine.SetState<StateAggression>();
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
           stateMachine.SetState<StatePatrul>();
        }    
    }

}
