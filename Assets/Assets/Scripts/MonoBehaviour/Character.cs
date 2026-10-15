using UnityEngine;

// BASE CLASS: dasar untuk semua makhluk di game (Player, Enemy, NPC, dst).
// Berisi komponen & perilaku yang dipakai bersama.
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public abstract class Character : MonoBehaviour
{
    public float speed = 4f;

    protected Rigidbody2D rb;
    protected Animator anim;
    protected Health health;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    protected virtual void OnEnable()  => health.OnDeath += Die;
    protected virtual void OnDisable() => health.OnDeath -= Die;

    void FixedUpdate() => Move();

    // Cara bergerak berbeda tiap karakter -> wajib di-override
    protected abstract void Move();

    // Perilaku default saat mati: berhenti & nonaktifkan script.
    // Class turunan boleh menambah perilaku lewat override.
    protected virtual void Die()
    {
        rb.linearVelocity = Vector2.zero;
        enabled = false;
    }
}
