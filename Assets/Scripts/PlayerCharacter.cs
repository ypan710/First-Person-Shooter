using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        // initialize the health value
        health = 5;
    }


    public void Hurt(int damage)
    {
        // decrement the player's health
        health -= damage;

        // construct the messagge by using string interpolation
        Debug.Log($"Health: {health}");
    }
}
