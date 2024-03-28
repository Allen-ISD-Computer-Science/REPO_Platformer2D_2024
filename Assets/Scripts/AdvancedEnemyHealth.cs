using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private bool dropItem = false;
    [SerializeField] public GameObject droppedItem;



    //Advanced enimies will take multiple hits to kill so they have health points and will die after loosing all their health
    public void Damage(int amount)
    {
        //Debug.Log("Ouch!");
        this.healthPoints -= amount;

        if (healthPoints <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        //Debug.Log("Enemy Dead");
        Destroy(gameObject);

        //after enemy death if dropItem is enabled set the dropped item to active so it "drops"
        if (dropItem)
        {
            droppedItem.SetActive(true);
        }
    }
}
