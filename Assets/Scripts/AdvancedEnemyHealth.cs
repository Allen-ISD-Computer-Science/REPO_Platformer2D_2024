using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthPoints = 3;


//Advanced enimies will take multiple hits to kill so they have health points and will die after loosing all their health
public void Damage(int amount) {
        //Debug.Log("Ouch!");
        this.healthPoints -= amount;

        if (healthPoints <= 0) {
            Die();
            }
    }


private void Die() {
    //Debug.Log("Enemy Dead");
    Destroy(gameObject);
    }
}
