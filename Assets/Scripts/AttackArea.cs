using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider) {    
        //Debug.Log("Attack has been triggered!!!!");
        if(collider.GetComponent<EnemyHealth>() != null) {
            //Debug.Log("I hit you!!!!");
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
        }

    }

}
