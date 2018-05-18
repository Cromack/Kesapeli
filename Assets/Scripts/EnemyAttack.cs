using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    Animator anim;
    public int damage = 15;
    public float attackInterval = 0.5f;
    PlayerHealth playerHealth;
    GameObject player;
    public bool combat = false;
    float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame

    void Update()
    {
        if(combat == true)
        {
            timer += Time.deltaTime;
            if(timer >= attackInterval)
            {
                Attack();
            }

        }
    }
    void Attack ()
    {
        anim.SetTrigger("CreatureAttack");
        playerHealth.TakeDamage(damage);
        timer = 0f;

	}

    
}
