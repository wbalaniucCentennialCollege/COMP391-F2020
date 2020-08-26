﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minX, minY, maxX, maxY;
    public GameObject laser, laserSpawn;
    public float fireRate = 0.25f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horiz, vert;

        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        // Debug.Log("H: " + horiz + ", V: " + vert);

        Vector2 newVelocity = new Vector2(horiz, vert);
        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;

        // Restrict the player from leaving the play area
        float newX, newY;

        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX); 
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);

        Debug.Log("Clamped X: " + newX + " Clamped Y: " + newY);

        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        // Add laser fire code
        // Check if the "Fire1" button is pressed
        if(Input.GetAxis("Fire1") > 0 && timer > fireRate) 
        {
            // If yes, spawn the laser
            // Instantiation: What do I instantiate? Where is it instantiated? What is its rotation?
            GameObject gObj;
            gObj = GameObject.Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            gObj.transform.Rotate(new Vector3(0, 0, 90));

            // Reset timer
            timer = 0;
        }

        timer += Time.deltaTime; // timer = timer + Time.deltaTime;
    }
}
