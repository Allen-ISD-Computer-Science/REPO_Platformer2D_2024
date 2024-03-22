using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    public int apples = 0;

    [SerializeField] private Text applesText;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {

            collision.gameObject.GetComponent<Animator>().Play("Collected");
            Destroy(collision.gameObject, 1.05f);
            apples++;
            applesText.text = "Apples: " + apples + "/6";
        }
    }  
}

