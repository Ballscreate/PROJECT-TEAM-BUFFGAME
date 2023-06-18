using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalPatrolPoints.patrolPoints.Add(transform.position);
    }

   
}
