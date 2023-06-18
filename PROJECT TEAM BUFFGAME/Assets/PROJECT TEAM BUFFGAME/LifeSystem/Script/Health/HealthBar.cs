using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;

    private UnitHealth _healthObject;

    private void Awake() {
        _healthObject = GetComponent<UnitHealth>();
    
    }
    private void OnEnable() {
        _healthObject.HealthChange += SetHpUI;
    }
     private void OnDisable() {
        _healthObject.HealthChange -= SetHpUI;
    }
    void SetHpUI(float health)
    {
        _hpBar.value = health/_healthObject.MaxHealth;
    }
}
