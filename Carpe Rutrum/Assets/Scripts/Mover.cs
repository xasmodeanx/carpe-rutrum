using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody rb;
    public float startingYPosition;




    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //now that we have built the entire level, let's loop through the GameObjects 
        //we created and set their active status to false.  Our render script will come back through
        //and re-enable them.
        
    }

    // Update is called once per frame
    void Update()
    {


        //Moves Forward and back along y axis                           //Up/Down
        transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);
        //Moves Left and right along x Axis                               //Left/Right
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);

        
    }

    private void FixedUpdate()
    {
        //if we are pressing the w key, turn off gravity so we can fly
        if (Input.GetKey(KeyCode.W) == true)
        {
            //rb.useGravity = false;
            //transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed * 4);
            rb.AddRelativeForce(Vector3.up * (rb.mass * Mathf.Abs(Physics.gravity.y))*2);
        }
        else
        {
            rb.useGravity = true;
        }
        //if a gameObject is directly above our heads, we die
        if (!CheckAlive())
        {
            //reset the player back to the start of the gameplane
            transform.position = new Vector3(0, startingYPosition, 0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        //other.gameObject.CompareTag.("Diggable")
        if (other.gameObject.name.Contains("Diggable"))
        {
            //Debug.Log("GameObject Hit: " + other.gameObject.name);
            
            //figure out where the collision occurred relative to the player
            //e.g. leftOf player, rightOf player, above player, below player
            string myCollisionHorz = GetCollisionPosHorz(other);
            string myCollisionVert = GetCollisionPosVert(other);

            switch (myCollisionHorz)
            {
                case "leftOf":
                    if ((Input.GetKey(KeyCode.A) == true) && (myCollisionVert == "above") && (!Input.GetKey(KeyCode.W))) { other.gameObject.SetActive(false); };
                    break;
                case "rightOf":
                    if ((Input.GetKey(KeyCode.D) == true) && (myCollisionVert == "above") && (!Input.GetKey(KeyCode.W))) { other.gameObject.SetActive(false); };
                    break;
                default:
                    //Debug.Log("Got a null case for Horz collision Position! " + myCollisionHorz.ToString());
                    break;
            }

            switch (myCollisionVert)
            {
                case "above":
                    if ((Input.GetKey(KeyCode.W) == true)) { Debug.Log("Can't Dig Upwards!"); };
                    break;
                case "below":
                    if ((Input.GetKey(KeyCode.S) == true)) { other.gameObject.SetActive(false); };
                    break;
                default:
                    //Debug.Log("Got a null case for Vert collision Position! " + myCollisionVert.ToString());
                    break;
            }

            
            

        }

        
    }

    //check if an x,y,z position intersects (collides) with another gameObject
    bool IsObjectHere(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 0.1f);
        return intersecting.Length != 0;
    }

    bool IsObjectHereGravityAffected(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 0.01f);
        foreach (Collider current in intersecting)
        {
            //Debug.Log("top collided with a " + current.name.ToString());
            if(current.name.Contains("GravityAffected"))
            {
                //current.attachedRigidbody.useGravity = true;
                //current.attachedRigidbody.isKinematic = false;
                //Debug.Log("Toggled gravity on block " + current.name.ToString());
                return true;
            }
        }
        return false;
    }

    string GetCollisionPosHorz(Collider collided)
    {
        string positionRelPlayerHorz = "";

        if (transform.position.x > collided.gameObject.transform.position.x)
        {
            //Debug.Log("Dirt block on left");
            positionRelPlayerHorz = "leftOf";
        }

        if (transform.position.x < collided.gameObject.transform.position.x)
        {
            //Debug.Log("dirt block on right");
            positionRelPlayerHorz = "rightOf";
        }

        return positionRelPlayerHorz;
    }

    string GetCollisionPosVert(Collider collided)
    {
        string positionRelPlayerVert = "";

        if (transform.position.y < collided.gameObject.transform.position.y)
        {
            //Debug.Log("Dirt block above");
            positionRelPlayerVert = "above";
        }

        if (transform.position.y > collided.gameObject.transform.position.y)
        {
            //Debug.Log("dirt block below");
            positionRelPlayerVert = "below";
        }

        return positionRelPlayerVert;
    }

    bool CheckAlive()
    {
        bool objectAbove = IsObjectHere(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
        bool suffocated = IsObjectHereGravityAffected(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
        if (objectAbove && suffocated)
        {
            Debug.Log("PLAYER IS DEAD FROM SUFFOCATION!!!!!!!!!!!!!!!!!!!!!");
            //restart game?
            return false;
        }


        //check to see if the player has intersected a GroundBlock with high velocity
        //i.e. they went splat
        
        if (rb.velocity.magnitude > 15f)
        {
            //Debug.Log("Player velocity was" + rb.velocity.magnitude.ToString());
            
            //start checking if there is something beneath us to hit...
            bool splatted = IsObjectHere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z));
            if (splatted)
            {
                Debug.Log("PLAYER IS DEAD FROM SUDDEN STOP!!!!!!!!!!!!!!!!!!!!!");
                //stop the falling
                rb.velocity = new Vector3(0, 0, 0);
                return false;
            }
        }
         
        

        //didn't die from anything above, therefore we are alive
        return true;
    }
  
}
