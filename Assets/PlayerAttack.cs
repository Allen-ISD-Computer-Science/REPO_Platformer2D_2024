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
            Attack();
        }
        
        if (attacking) {

            timer += Time.deltaTime;

            if(timer >= timeToAttack) {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);

            }
        }

        UpdateAnimationState();
        
    }

    private void Attack() {
        attacking = true;
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
