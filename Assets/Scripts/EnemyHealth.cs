using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthPoints = 100;
    [SerializeField] private int MAX_HEALTH = 100;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        
    }

    public void Damage(int amount) {
        //Debug.Log("Ouch!");
        if(amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.healthPoints -= amount;

        if (healthPoints <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        if(amount < 0) {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }
        
        bool overMaxHealth = healthPoints + amount > MAX_HEALTH;

        if(overMaxHealth){
            this.healthPoints = MAX_HEALTH;
        } else {
            this.healthPoints += amount;
        }
    
}

private void Die() {
    Debug.Log("Enemy Dead");
    Destroy(gameObject);
    }
}
