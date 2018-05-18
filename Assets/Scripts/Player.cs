using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    public int speed;
    public int MaxSpeed;
    public int Damage = 10;
    PlayerHealth playerHealth;

    GameObject Target;
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
                if (Input.GetButton("Horizontal"))
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

            case State.Combat:
                if (Input.GetButtonDown("Jump"))
                {
                    animator.SetTrigger("Attack");
                    Target.GetComponent<EnemyHealth>().TakeDamage(Damage);
                }
                break;
        }
            
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }
   
	
	// Update is called once per frame
	void Update () {
        ChangeState();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector2.zero;
            CurrentState = State.Combat;
            animator.SetBool("Walking", false);
            Target = other.gameObject;
            other.gameObject.GetComponent<EnemyAttack>().combat  = true;
            
        }
    }
}
