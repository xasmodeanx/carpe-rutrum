using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();
        
        //Set the main Color of the Material to green
        //rend.material.shader = Shader.Find("Standard");
        //Color newColor = new Color32(210, 105, 30, 255);
        Color newColor = new Color((210.0f/255.0f) + Random.Range(-0.1f, 0.1f), (105.0f / 255.0f) + Random.Range(-0.1f, 0.1f), (30.0f / 255.0f) + Random.Range(-0.1f, 0.1f));
        rend.material.SetColor("_Color", newColor);
        
        //Find the Specular shader and change its Color to red
        //rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_SpecColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
