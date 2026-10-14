using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    public float Current { get; private set; }
    public float Max => maxHealth;

    public event Action<float, float> OnHealthChanged;
    public event Action OnDeath;

    void Awake() => Current = maxHealth;

    public void TakeDamage(float amount)
    {
        if (Current <= 0) return;
        Current = Mathf.Max(Current - amount, 0);
        OnHealthChanged?.Invoke(Current, maxHealth);
        if (Current <= 0) OnDeath?.Invoke();
    }

    public void Heal(float amount)
    {
        if (Current <= 0) return;
        Current = Mathf.Min(Current + amount, maxHealth);
        OnHealthChanged?.Invoke(Current, maxHealth);
    }
}