using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount) {
        if(amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        if(amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }
        
        bool overMaxHealth = health + amount > MAX_HEALTH;

        if(overMaxHealth){
            this.health = MAX_HEALTH;
        } else {
            this.health += amount;
        }
    
}

private void Die() {
    Debug.Log("I am dead");
    }
}