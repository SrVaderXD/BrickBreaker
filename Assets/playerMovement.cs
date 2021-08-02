using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            rb.AddForce(new Vector2(speed, 0));
        }
        else if (Input.GetKey("left"))
        {
            rb.AddForce(new Vector2(-speed, 0));
        }
        
        if(Input.GetKeyUp("right") || Input.GetKeyUp("left")){
            rb.velocity = new Vector2(0,0);
        }
    }
}
