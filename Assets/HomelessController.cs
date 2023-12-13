using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HomelessController : MonoBehaviour
{
    Animator animator;

    Vector2 movement;

    bool isAttacking = false;

    [SerializeField] AnimationClip attackDown;

    // string lastDirection = "down"; //use to know what direction last walked in, set "up", "left"....

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float walkSpeed = 5 * Time.deltaTime;

        // if (Input.GetAxisRaw("Fire1") > 0) animator.SetTrigger("Attack");

        // float moveX = Input.GetAxisRaw("Horizontal");
        // float moveY = Input.GetAxisRaw("Vertical");

        // animator.SetFloat("x", moveX);
        // animator.SetFloat("y", moveY);

             if (movement.x > 0) animator.Play("walkRight");
        else if (movement.x < 0) animator.Play("walkLeft");
        else if (movement.y > 0) animator.Play("walkUp");
        else if (movement.y < 0) animator.Play("walkDown");
        // else animator.Play("idleDown");

        // Vector3 movement = new Vector3(moveX, moveY, 0).normalized * walkSpeed;
        // transform.position += movement;

        transform.Translate(movement * walkSpeed);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnFire()
    {
        isAttacking = true;
        animator.Play(attackDown.name);
        Invoke("StopAttacking", attackDown.length);
    }

    void StopAttacking() => isAttacking = false;
}
