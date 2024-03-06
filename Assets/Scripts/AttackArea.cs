using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int attackPower = 1;

    //basic enimies and adavanced enimies are treated seperatly due to being differnt classes
    //attack power only matter for advanced enimies
    private void OnTriggerEnter2D(Collider2D collider) {    
        //Debug.Log("Attack has been triggered!!!!");
        
        if(collider.GetComponent<BasicEnemyHealth>() != null) {
            //Debug.Log("I hit you!!!!");
            BasicEnemyHealth health = collider.GetComponent<BasicEnemyHealth>();
            health.Damage();
        }

        if(collider.GetComponent<AdvancedEnemyHealth>() != null) {
            //Debug.Log("I hit you!!!!");
            AdvancedEnemyHealth health = collider.GetComponent<AdvancedEnemyHealth>();
            health.Damage(attackPower);
        }

    }

}
