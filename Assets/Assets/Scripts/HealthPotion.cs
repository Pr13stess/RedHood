using UnityEngine;

public class HealthPotion : Consumable
{
    protected override void Apply(Health target)
    {
        target.Heal(amount);
        Debug.Log("Health Potion dipakai: +" + amount + " HP");
    }
}