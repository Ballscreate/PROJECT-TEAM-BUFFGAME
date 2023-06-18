using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private UnitHealth _health;
    private void Update() {
    if(Input.GetKeyDown(KeyCode.F))
    {
        _health.TakeDamage(damage);
    }
}
}
