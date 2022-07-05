using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    // values for the speed of movement and the distance at which to react to obstacles
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    // boolean value to track whether the enemy is alive
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        // initialize that value
        isAlive = true;
    }
    // Update is called once per frame
    void Update()
    {
        // move only if the character is alive
        if (isAlive)
        {
            // move forward continuously every frame, regardless of turning
            transform.Translate(0, 0, speed * Time.deltaTime);
            // a ray in the same position and pointing in the same direction as the character
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            // perform raycasting with a circular volume around the ray
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                // player is detected in the same way as they target object in RayShooter
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    // same null GameObject logic as SceneController
                    if (fireball == null)
                    {
                        // Instantiante() method here is just as it was in SceneController
                        fireball = Instantiate(fireballPrefab) as GameObject;
                        // place the fireball in front of the enemy and point in the same direction
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    // turn toward a semi-random new direction
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    // public method allowing outside code to affect the "alive" state
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
}
