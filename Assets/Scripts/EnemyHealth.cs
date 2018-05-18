using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 50;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.


    // Use this for initialization
    void Awake () {
        currentHealth = startingHealth;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damageTaken)
    {


        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
