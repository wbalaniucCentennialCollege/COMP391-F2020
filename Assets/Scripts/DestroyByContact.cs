using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Something has collided
        // Add new code here!

        // Create an explosion 
        Instantiate(explosion, transform.position, transform.rotation);

        // Delete the "other" object
        Destroy(other.gameObject);
        // Delete this object
        Destroy(this.gameObject);
    }
}
