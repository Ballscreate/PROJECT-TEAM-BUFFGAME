using System;
using Mirror;
public abstract class UnitDeath : NetworkBehaviour
{
    
    public Action OnDeath;

    private UnitHealth _healthObject;
    private void Awake() 
    {
     _healthObject = GetComponent<UnitHealth>();   
    }
    private void OnEnable() {
        
        _healthObject.HealthChange += СheckDeathObject;
         OnDeath +=  DeathLogic;
    }
    private void OnDisable() {
        _healthObject.HealthChange -= СheckDeathObject;
         OnDeath -=  DeathLogic;
    }
    [Client]
    private void СheckDeathObject(float health)
        if(health <= 0)
        {
           OnDeath?.Invoke();
        }
    }

    
    protected abstract void DeathLogic();
}
