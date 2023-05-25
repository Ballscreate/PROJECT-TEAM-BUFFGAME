using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastBotLogic : MonoBehaviour
{
    [Space]
    [Header("State")]
    [SerializeField]private State StartState;
    [SerializeField]private State Patrul;
    [SerializeField]private State Agressive;
    [SerializeField]private State curentState;

    [Space]
    public Transform Target;

    [Space]
    private List<GameObject> _purposes = new();
    public GameObject purpose{get;private set;}

    public Transform _Tr;
    private void Start()
    {
        _Tr = transform;
        SetState(StartState);
    }

    void Update()
    {
        if(!curentState.IsFinished)
        {
            curentState.Run();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _purposes.Add(other.gameObject);
            purpose = _purposes[0];
            SetState(Agressive);
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            SetState(Patrul);
        }    
    }
   private void SetState(State state)
   {
        curentState = Instantiate(state);
        curentState.Bot = this;
        curentState.Init();
   }
}
