using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour
{

//basic enimies will die in one hit so they don't require any health points
public void Damage() {
        //Debug.Log("Ouch!");
        Die();
        }

    
private void Die() {
    //Debug.Log("Enemy Dead");
    Destroy(gameObject);
    }
}


