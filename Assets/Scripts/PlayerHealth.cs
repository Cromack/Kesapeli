using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider Health;                                 // Reference to the UI's health bar.
   
    void Awake ()
    {
        currentHealth = startingHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        Debug.Log(damageTaken);
        Health.value = currentHealth;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
