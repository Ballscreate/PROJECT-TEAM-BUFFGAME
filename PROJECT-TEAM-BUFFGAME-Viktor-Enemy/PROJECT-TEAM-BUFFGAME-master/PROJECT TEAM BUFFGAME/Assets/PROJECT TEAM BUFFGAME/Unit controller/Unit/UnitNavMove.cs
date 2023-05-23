using UnityEngine;
using UnityEngine.AI;

public class UnitNavMove : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform Target;

    [SerializeField] private Transform Unit;


    private Transform _Nav;

    private NavMeshAgent _unit;
    private Vector3 _current;
    void Start()
    {
        _Nav = transform;
        _unit = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (true)
        {
            _unit.SetDestination(Target.position); // эта операция "тяжелая" и она происходит только при изменении позиции цели
        }

        if (_Nav.position != Unit.position)
        {
            Unit.position =_Nav.position; // это нужно что бы NavMash не проицировал наклон "rotation"
        }

        _current = Target.position;
    }
}
