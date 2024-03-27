using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public itemCollector script;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D collision) {
// Could use other.GetComponent<Player>() to see if the game object has a Player component
// Tags work too. Maybe some players have different script components?
if (collision.tag == "Player" && script.apples == 6)
        {
            // Player entered, so move level
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
