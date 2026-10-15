using UnityEngine;
using UnityEngine.InputSystem;

// TURUNAN dari Character: karakter yang digerakkan oleh keyboard
public class PlayerMovement : Character
{
    Vector2 input;
    Vector2 lastDir = Vector2.down;

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        input = new Vector2(
            (kb.dKey.isPressed || kb.rightArrowKey.isPressed ? 1 : 0) -
            (kb.aKey.isPressed || kb.leftArrowKey.isPressed ? 1 : 0),
            (kb.wKey.isPressed || kb.upArrowKey.isPressed ? 1 : 0) -
            (kb.sKey.isPressed || kb.downArrowKey.isPressed ? 1 : 0)
        ).normalized;

        bool moving = input.sqrMagnitude > 0.01f;
        if (moving) lastDir = input;

        anim.SetBool("IsMoving", moving);
        anim.SetFloat("MoveX", lastDir.x);
        anim.SetFloat("MoveY", lastDir.y);
    }

    protected override void Move()
    {
        rb.linearVelocity = input * speed;
    }

    protected override void Die()
    {
        base.Die();                      // berhenti + nonaktif (dari Character)
        anim.SetBool("IsMoving", false); // tambahan khusus player
        Debug.Log("Player mati!");
    }
}
