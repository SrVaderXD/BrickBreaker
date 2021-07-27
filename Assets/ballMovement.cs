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
        checkDefeat();
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");

        if (bricks.Length == 0)
        {
            Debug.Log("Win!!");
        }

        Debug.Log((dx * speed));
        Debug.Log((dy * speed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        float angle = 0;

        if (collision.gameObject.tag == "Player")
        {

            if (Random.Range(0, 100f) < 50f)
            {
                angle = Random.Range(20f, 45f);
            }
            else
            {
                angle = Random.Range(90f + 20f, 90f + 45f);

            }

            dx = Mathf.Cos(Mathf.Deg2Rad * angle);
            dy = Mathf.Sin(Mathf.Deg2Rad * angle);

            if (dy < 0)
            {
                dy *= -1;
            }

            speed = 0.2f;
        }
        else if (collision.gameObject.tag == "wall_left" || collision.gameObject.tag == "wall_right")
        {
            dx = -1;
        }
        else if (collision.gameObject.tag == "brick")
        {
            dy = -1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "unbreakable_brick")
        {
            dy = -1;
        }


    }

    void checkDefeat()
    {
        if (transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
