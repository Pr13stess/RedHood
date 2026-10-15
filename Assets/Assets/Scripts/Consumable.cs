using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Consumable : MonoBehaviour
{
    [SerializeField] protected float amount = 10f;

    void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() == null) return;

        Health health = other.GetComponent<Health>();
        if (health == null) return;

        Apply(health);          
        Destroy(gameObject);    
    }

    protected abstract void Apply(Health target);
}