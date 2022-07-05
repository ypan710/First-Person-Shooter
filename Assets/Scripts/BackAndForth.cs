using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    // these are the positions the object moves between
    public float speed = 3.0f;
    public float maxZ = 16.0f;
    public float minZ = -16.0f;

    // which direction is the object currently moving in?
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);

        bool bounced = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            // toggle the direction back and forth
            direction = -direction;
            bounced = true;
        }
        // apply a second movement in the new direction if the object switched directions
        if (bounced)
        {
            transform.Translate(0, 0, direction * speed * Time.deltaTime);
        }
    }
}
