using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour
{

    [SerializeField] private bool dropItem = false;
    [SerializeField] public GameObject droppedItem;

    //basic enimies will die in one hit so they don't require any health points
    public void Damage()
    {
        //Debug.Log("Ouch!");
        Die();
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


