using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetMoveInput : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform Target;

    [Space]
    [SerializeField] private float MaxDistansTarget = 1;
    [SerializeField] private float FactorDistansTarget = 1;

    private Vector3 _Input;

    void Update()
    {
        _Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if((_Input * FactorDistansTarget).magnitude > MaxDistansTarget)
        {
            _Input = _Input.normalized * MaxDistansTarget;
        }

        Target.localPosition = _Input;
    }
}
