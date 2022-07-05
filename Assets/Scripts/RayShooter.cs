using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // access other components attached to the same object
        cam = GetComponent<Camera>();

        // hide the mouse cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        // these are just the rough size of this font
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        // the GUI.Label() command displays text onscreen
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        // respond to the left (first) mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // the middle of the screen is half its width and height
            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);

            // create the ray at that position by using ScreenPointToRay()
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;

            // the raycasts fills a referenced variable with information
            if (Physics.Raycast(ray, out hit))
            {
                // retrieve the object the ray hit
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                // check for the ReactiveTarget component on the object
                if (target != null)
                {
                    // call a method of the target instead of just emitting the debug message
                    target.ReactToHit();
                }
                else {
                    // launch a coroutine response to a hit
                    StartCoroutine(SphereIndicator(hit.point));
                }
                
            }

        }
    }

    // coroutines use IEnumerator functions
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        // the yield keyword tells coroutines where to pause
        yield return new WaitForSeconds(1);

        // remove this GameObject and clear its memory
        Destroy(sphere);
    }
}
