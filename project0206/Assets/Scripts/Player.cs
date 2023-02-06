using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3;

    float vx = 0;
    float vy = 0;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        //rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        //rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -speed;
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(vx, vy);
    }
}
