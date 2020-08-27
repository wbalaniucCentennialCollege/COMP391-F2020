using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int scoreValue = 10;
    public GameObject explosion;

    private GameController gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerScript == null)
        {
            Debug.Log("Cannot find game controller script on GameController object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Something has collided
        if(other.gameObject.CompareTag("Player"))
        {
            // Collided with the player
            Instantiate(explosion, other.transform.position, other.transform.rotation);

            // Initiate game over
            gameControllerScript.GameOver();
        }
        

        // Create an explosion 
        Instantiate(explosion, transform.position, transform.rotation);
        gameControllerScript.AddToScore(scoreValue);

        // Delete the "other" object
        Destroy(other.gameObject);
        // Delete this object
        Destroy(this.gameObject);
    }
}
