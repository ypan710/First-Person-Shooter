using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    // topple enemy, wait 1.5 seconds, and then destroy the enemy
   private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        // a script can destroy itself (just as it could a separate object)
        Destroy(this.gameObject);
    }


    // method called by the shooting script
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        // check if this character has a WanderingAI script; it might not
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }
}
