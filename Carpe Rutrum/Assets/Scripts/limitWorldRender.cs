using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitWorldRender : MonoBehaviour
{
    public bool LimitRenderRange = false;
    private GameObject[] allGameObjectsDiggable;
    public float RenderRange = 20f;
    public float RenderCheckWait = 2f;
    public float DeRenderRange = 20f;
    public float DeRenderCheckWait = 30f;



    // Start is called before the first frame update at the start of the game (i.e. only runs once)
    void Start()
    {
        //now that we have built the entire level, let's loop through the GameObjects 
        //we created and set their active status to false.  Our render script will come back through
        //and re-enable them.
        if (LimitRenderRange)
        {
            allGameObjectsDiggable = GameObject.FindGameObjectsWithTag("Diggable");
            foreach (GameObject current in allGameObjectsDiggable)
            {
                //Debug.Log("Found a diggable object: " + current.gameObject.name.ToString());
                // Do not use gameObject.SetActive(bool) because OnDisable() will stop the physics callback listeners

                current._SetVisibility(false);
                //current.gameObject.SetActive(false);
                
            }
            
        }



    }
    //test
    // Update is called once per frame during the life of the game execution
    void Update()
    {
        //if the LimitRenderRange checkbox is true, spin off a thread to do the render/derender math
        //so that our main game thread isn't choked to death doing array read/writes on every frame
        if (LimitRenderRange)
        {
            StartCoroutine("RenderObjectsNearMe");
            
        }
    }

    //Awake is a Unity entrance point that get's executed as soon as the game is started. 
    //Awake is run before Update and only runs one time
    private void Awake()
    {

        
    }

    //IEnumerator type means this function executes in it's own thread and returns when it is ready
    IEnumerator RenderObjectsNearMe()
    {
        //int RenderCount = 0;
        foreach (GameObject current in allGameObjectsDiggable)
        {
            float distance = Vector3.Distance(current.transform.position,transform.position);
            if(distance <= RenderRange && !current._getVisibility())
            {
                // Do not use gameObject.SetActive(bool) because OnDisable() will stop the listeners
                current._SetVisibility(true);
                //RenderCount++;
                //Debug.Log("enabled " + current.name.ToString());
            }
            else if (distance >= DeRenderRange && current._getVisibility())
            {
                current._SetVisibility(false);
            }
            //Debug.Log("RenderCount was " + RenderCount);
        }
        yield return new WaitForSeconds(RenderCheckWait);
    }

    
}

//we must extend the Unity GameObject class because if we use the Unity built-in function to 
//activate or deactivate GameObjects, upon Deactivation, all callback listener threads in the game engine 
//are cut off, e.g. physics, collisions.  This means that even if you reactivate your GameObject 
//using GameObject.setActive(true), you never get physics or collisions on that object ever again
//This extension to the GameObject class forcibly goes in and disables components of GameObjects that are 
//intensive to render but keep the object still "active" so we don't lose those hooks for the physics and collision
//callbacks. 
public static class Extension
{
    // Do not use gameObject.SetActive(bool) because OnDisable() will stop the listeners
    public static void _SetVisibility(this GameObject gameObject, bool visible)
    {
        /*
        * For 3D Objects
        */
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = visible;
        }

        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        if (renderers != null)
        {
            foreach (var r in renderers)
            {
                r.enabled = visible;
            }
        }

        Collider collider = gameObject.GetComponent<Collider>();

        if (collider != null)
        {
            collider.enabled = visible;
        }

        Renderer[] colliders = gameObject.GetComponentsInChildren<Renderer>();
        if (colliders != null)
        {
            foreach (var c in colliders)
            {
                c.enabled = visible;
            }
        }

        Light lighter = gameObject.GetComponent<Light>();

        if (lighter != null)
        {
            lighter.enabled = visible;
            
        }
        /*
        * For UI Sprites Object
        */
        /*
        Image image = gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.enabled = visible;
        }
        */
    }

    public static bool _getVisibility(this GameObject gameObject)
    {
        
        /*
        * For 3D Objects
        */
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.enabled;
        }
        else
            return false;
    }
}