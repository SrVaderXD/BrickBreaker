using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float dx = 0, dy = -0.01f;
    public float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (dx * speed), transform.position.y + (dy * speed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            float angle = Random.Range(-45f, 45f);
            dx = Mathf.Cos(Mathf.Deg2Rad * angle);
            dy = Mathf.Sin(Mathf.Deg2Rad * angle);

            if(dy < 0){
                dy *= -1;
            }

            speed = 0.2f;
        }
        else if (collision.gameObject.tag == "wall_left" || collision.gameObject.tag == "wall_right")
        {
            dx = -1;
        }
    }
}
