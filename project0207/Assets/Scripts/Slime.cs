using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float vx = speed;

        rbody.velocity = new Vector2(vx, rbody.velocity.y);

        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Goal")
        {
            speed = -1 * speed;
        }

        if(collision.gameObject.tag == "Stone")
        {
            Destroy(this.gameObject);
        }
    }
}
