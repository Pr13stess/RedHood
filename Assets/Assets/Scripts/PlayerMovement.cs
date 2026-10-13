using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;

    Rigidbody2D rb;
    Animator anim;
    Vector2 input;
    Vector2 lastDir = Vector2.down;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

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

    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}