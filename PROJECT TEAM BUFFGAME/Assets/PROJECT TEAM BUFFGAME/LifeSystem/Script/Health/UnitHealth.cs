using System;
using UnityEngine;
using Mirror;

public class UnitHealth : NetworkBehaviour
{
   public Action<float> HealthChange;

   [SerializeField]private float _maxHealth;
   private float _health;
   
   public float MaxHealth
   {
    get
    {
        return _maxHealth;
    }
    set
    {
      if(value >= 0)
      {
        _maxHealth = value;
      }
    }
   }

   public float Healths
    {
        get
        {
          return _health;
        }
        set
        {
          if(value <= MaxHealth) 
          {
            _health =  Mathf.Clamp(value,0,MaxHealth);
          }
        }
    }
    
    private void Start() 
    {
        Healths = MaxHealth;
    }    
   [Server]
    public void TakeDamage(float damage)
    {
        if(damage <= 0)  return;
        
         Healths -= damage;
         HealthChange?.Invoke(Healths);
    }
    [Command]
    public void CmdTakeDamage(float damage)
    {
        TakeDamage(damage);
    }

    
}
