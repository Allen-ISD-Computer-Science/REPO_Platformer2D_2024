using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    
    private bool attacking = false;

    private float timeToAttack = 1f;
    float timer = 0f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(2).gameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("I'm gonna attack");
            Attack();
        }
        
        if (attacking) {

            timer += Time.deltaTime;

            if(timer >= timeToAttack) {
                timer = 0;
                Debug.Log("I've finished my attack");
                attacking = false;
                attackArea.SetActive(attacking);

            }
        }

        UpdateAnimationState();
        
    }

    private void Attack() {
        attacking = true;
        Debug.Log("Attacking time");
        attackArea.SetActive(attacking);
        
    }

    private void UpdateAnimationState()
    {
        if (attacking) {
            anim.SetBool("attacking", true); 
        } else {
            anim.SetBool("attacking", false); 
        }
    }

}
