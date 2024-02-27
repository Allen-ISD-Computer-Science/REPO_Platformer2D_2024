using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int healthPoints = 100;

    private int MAX_HEALTH = 100;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //test damage
        if (Input.GetKeyDown(KeyCode.F1)) {
            Damage(10);
        }


        //test health
        if (Input.GetKeyDown(KeyCode.F2)) {
            Heal(10);
        }

        
    }

    public void Damage(int amount) {
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
    Debug.Log("I am dead");
    //Destroy(gameObject);
    }
}