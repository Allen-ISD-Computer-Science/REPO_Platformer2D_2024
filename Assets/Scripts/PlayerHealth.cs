using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private Transform cam;
    [SerializeField] private Transform background;
    
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private int MAX_HEALTH = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update

    
    
    // Update is called once per frame 
    void Update()
    {       
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < healthPoints; i++)
        {
            hearts[i].sprite = fullHeart;
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
    cam.parent = null;
    background.parent = null;
    Destroy(gameObject);
    }
}