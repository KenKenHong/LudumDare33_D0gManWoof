using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 1.0f;

    private Animator anim;
    private Rigidbody2D rb;
    private int floorMask;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        floorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Move(moveX, moveY);

        Turning();

        Animating(moveX, moveY);
    }

    void Move(float x, float y)
    {
        /*
         movement.Set(x, y, 0f);
         movement = movement.normalized * movespeed * Time.deltaTime;
         rb.MovePosition(transform.position + movement);
         */

        Vector3 movement = new Vector3(0f, 0f, 0f);

        if(Input.GetKey(KeyCode.W))
        {
            movement += transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        movement = movement.normalized * movespeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2) transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + (int)transform.rotation.z - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Animating(float x, float y)
    {
        if (x != 0 || y != 0)
            anim.SetBool("Moving", true);
        else
            anim.SetBool("Moving", false);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            anim.SetBool("Sneaking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
            anim.SetBool("Sneaking", !anim.GetBool("Sneaking"));


    }
}
