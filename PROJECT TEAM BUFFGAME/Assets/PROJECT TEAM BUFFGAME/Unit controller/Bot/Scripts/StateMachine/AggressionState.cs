using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "State/AggressionState")]
public class AggressionState : State
{
    [SerializeField] private float MinDistansAttack;
    public override void Run()
    {
        Aggression();
    }
    void Aggression()
    {
        Bot.Target.position = Bot.purpose.transform.position + new Vector3(0,2,0);
        if((Bot.Target.position - Bot._Tr.position).magnitude < MinDistansAttack)
        {
            Debug.Log("Attack");
        }
    }
}
