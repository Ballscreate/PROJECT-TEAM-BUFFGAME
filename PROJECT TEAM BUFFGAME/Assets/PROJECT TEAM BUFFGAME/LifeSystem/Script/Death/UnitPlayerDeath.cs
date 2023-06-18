using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlayerDeath : UnitDeath
{
    protected override void DeathLogic()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}
