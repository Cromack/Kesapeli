using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public Rigidbody2D rb;
    public int speed;
    public int MaxSpeed;
    Animator animator;

    enum State{
        Idle,
        Walking,
        Combat
    };
    
    State CurrentState = State.Idle;

    void ChangeState()
    {
        switch (CurrentState)
        {
            case State.Idle:
                if (Input.GetButtonDown("Horizontal") == true)
                {
                    CurrentState = State.Walking;
                    animator.SetBool("Walking", true);
                    //animator.SetTrigger("Attack");
                }
                break;

            case State.Walking:

                float accelerate = Input.GetAxis("Horizontal");
                Vector2 acceleration = new Vector2(accelerate, 0);
                rb.AddForce(acceleration * speed);

                rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);

                if (Input.GetButton("Horizontal") == false)
                {
                    CurrentState = State.Idle;
                    animator.SetBool("Walking", false);
                }

                break;
        }
            
    }
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        ChangeState();
    }
}
