using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGravityNearMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ToggleGravity();
    }


    bool IsObjectHereGravityAffected(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 1.0f);
        foreach (Collider current in intersecting)
        {
            //Debug.Log("top collided with a " + current.name.ToString());
            if (current.name.Contains("GravityAffected"))
            {
                if (current.attachedRigidbody.useGravity == false)
                {
                    current.attachedRigidbody.useGravity = true; current.attachedRigidbody.isKinematic = false;
                    //Debug.Log("new Toggled gravity on block " + current.name.ToString());
                    current.attachedRigidbody.WakeUp();
                    //apply a little manual gravitational force to it as well
                    current.attachedRigidbody.AddForce(transform.up * -0.1f);
                }
                else
                {
                    //Debug.Log("Made no changes to gravity");
                }

                //current.attachedRigidbody.isKinematic = false;
                
                return true;
            }
        }
        return false;
    }

    void ToggleGravity()
    {
        //check all blocks around us to see if there are some affected by gravity
        IsObjectHereGravityAffected(new Vector3(transform.position.x, transform.position.y, transform.position.z));
       

    }
}
