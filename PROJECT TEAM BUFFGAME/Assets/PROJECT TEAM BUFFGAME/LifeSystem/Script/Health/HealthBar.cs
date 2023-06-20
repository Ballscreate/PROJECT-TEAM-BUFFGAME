using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class HealthBar : NetworkBehaviour
{
   private Slider _hpBar;

    private UnitHealth _healthObject;
    
    private void Awake() {
        _healthObject = GetComponent<UnitHealth>();
    }
    private void Start() {
      
        _hpBar = GameObject.FindWithTag("UIHpBar").GetComponent<Slider>();
    }
    private void OnEnable() {

        _healthObject.HealthChange += SetHpUI;
    }
     private void OnDisable() {
        _healthObject.HealthChange -= SetHpUI;
    }
    [TargetRpc]
    void SetHpUI(float health)
    {
        if(!isLocalPlayer) return;
        _hpBar.value = health/_healthObject.MaxHealth;
    }
   
}
