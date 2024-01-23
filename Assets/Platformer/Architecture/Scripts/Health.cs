using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    #region CONSTANTA
    [SerializeField] private UnityEvent<int, int> HealthChange;
    [SerializeField] private UnityEvent<int, int> MaxHealthChange;
    [SerializeField] private UnityEvent DeathEvent;

    public Action<int> OnHealthChange;
    public Action<int> OnMaxHealthChange;

    [Min(0)]
    [SerializeField] private int _health = 10;
    [Min(0)]
    [SerializeField] private int _maxHealth = 10;

    public Action OnDeath;

    public int GetHealth => _health; 
    #endregion
    public void ApplyDamage(int damage)
    {
#if UNITY_EDITOR
        if (damage < 0)
        {
            Debug.LogError("Damage isn't correct: " + damage);
            return;
        }
        else
        {
            ChangeHealth(-damage);
            return;
        } 
#endif
        ChangeHealth(-damage);
    }

    public void ApplyHeal(int heal)
    {
#if UNITY_EDITOR
        if (heal <= 0)
        {
            Debug.LogError("Damage isn't correct: " + heal);
            return;
        }
        else
        {
            ChangeHealth(heal);
            return;
        } 
#endif
        ChangeHealth(heal);
    }

    public void MaxHealthHeal()
    {
        ChangeHealth(_maxHealth - _health);
    }

    public void SetMaxHealth(int newMaxHealth)
    {
#if UNITY_EDITOR
        if (newMaxHealth <= 0)
        {
            Debug.LogError("maxHealth isn't correct: " + newMaxHealth);
            return;
        }
        else
        {
            ChangeMaxHealth(newMaxHealth);
            return;
        } 
#endif
        ChangeMaxHealth(newMaxHealth);
    }

    private void ChangeMaxHealth(int newMaxHealth)
    {
        MaxHealthChange?.Invoke(_maxHealth, newMaxHealth);
        OnMaxHealthChange?.Invoke(newMaxHealth);
        _maxHealth = newMaxHealth;
    }

    private void ChangeHealth(int changeValue)
    {
        _health += changeValue;
        if (_health <= 0)
        {
            _health = 0;
            Death();
        }
        else if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        HealthChange?.Invoke(_health, changeValue);
        OnHealthChange?.Invoke(_health);
    }
    private void Death()
    {
        DeathEvent?.Invoke();
        OnDeath?.Invoke();
    }
}