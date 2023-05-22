using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastBotLogic : MonoBehaviour
{
    [Space]
    [SerializeField] private Vector2 SizePatrol;

    [Space]
    [SerializeField] private bool Patrol;

    [Space]
    [SerializeField] private Transform Target;

    [Space]
    [SerializeField] private float MinDistansTarget;

    private Transform _Tr;

    private void Start()
    {
        _Tr = transform;
    }

    void Update()
    {
        if((Target.position - _Tr.position).magnitude <= MinDistansTarget && Patrol)
        {
            Target.position = new Vector3
                (
                Random.RandomRange(-SizePatrol.x, SizePatrol.x),
                Random.RandomRange(-SizePatrol.y, SizePatrol.y)
                );
        }
    }
}
