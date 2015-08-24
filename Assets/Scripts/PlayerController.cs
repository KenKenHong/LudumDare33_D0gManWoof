using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public AudioClip howl;
    public AudioClip footsteps;
    public float movespeed = 1.0f;
    public float turnspeed = 5f;

    private Animator anim;
    private HashIDs hash;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Move(moveX, moveY);
        Turning();
        Animating(moveX, moveY);
        Audio();
    }

    void Move(float x, float y)
    {
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
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, rotation, turnspeed * Time.deltaTime);
        rb.MoveRotation(newRotation);
    }

    void Animating(float x, float y)
    {
        if (x != 0 || y != 0)
            anim.SetBool(hash.movingBool, true);
        else
            anim.SetBool(hash.movingBool, false);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger(hash.attackingTrigger);
            anim.SetBool(hash.sneakingBool, false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
            anim.SetBool(hash.sneakingBool, !anim.GetBool(hash.sneakingBool));
    }

    void Audio()
    {

    }
}
