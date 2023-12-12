using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float walkSpeed = 5 * Time.deltaTime;

        // if (Input.GetAxisRaw("Fire1") > 0) animator.SetTrigger("Attack");

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // animator.SetFloat("x", moveX);
        // animator.SetFloat("y", moveY);

             if (moveX > 0 && Input.GetAxisRaw("Fire1") > 0) animator.Play("attackRight");
        else if (moveX < 0 && Input.GetAxisRaw("Fire1") > 0) animator.Play("attackLeft");
        else if (moveY > 0 && Input.GetAxisRaw("Fire1") > 0) animator.Play("attackUp");
        else if (moveX < 0 && Input.GetAxisRaw("Fire1") > 0) animator.Play("attackDown");
        else if (moveX > 0) animator.Play("walkRight");
        else if (moveX < 0) animator.Play("walkLeft");
        else if (moveY > 0) animator.Play("walkUp");
        else if (moveY < 0) animator.Play("walkDown");
        // else animator.Play("idleDown");

        Vector3 movement = new Vector3(moveX, moveY, 0).normalized * walkSpeed;
        transform.position += movement;
    }
}
