using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "State/PatrulState")]
public class PatrulState : State
{
    [SerializeField] private float MinDistansTarget;

    [SerializeField] private Vector2 SizePatrol;
    public override void Run()
    {
       if((Bot.Target.position - Bot._Tr.position).magnitude <= MinDistansTarget)
       {
            Patrul();
       }
    }
    void Patrul()
    {
        Bot.Target.position = new Vector3
        (
            Random.RandomRange(-SizePatrol.x, SizePatrol.x),
            Random.RandomRange(-SizePatrol.y, SizePatrol.y)
        );
    }
}
