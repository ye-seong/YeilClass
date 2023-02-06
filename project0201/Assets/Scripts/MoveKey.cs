using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKey : MonoBehaviour
{
    public float speed = 2;

    float vx = 0;
    float vy = 0;

    bool flipFlag = false;

    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = this.GetComponent<Rigidbody2D>();
        rigid2D.gravityScale = 0; //GetComponent<Rigidbody2D>().gravityScale = 0; //중력크기를 0으로
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation; //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; //회전하지 못하게
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;
        if (Input.GetKey(KeyCode.RightArrow)) //오른쪽으로 가기
        {
            vx = speed;
            flipFlag = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽으로 가기
        {
            vx = -speed;
            flipFlag = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vy = speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vy = -speed;
        }
    }

    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(vx, vy);

        //if (count == 0)
        //{
        //    rigid2D.velocity = new Vector2(5, 0);
        //}

        //if (count == 50)
        //{
        //    rigid2D.velocity = new Vector2(0, 0);
        //}

        //count = count + 1;

        //this.transform.Translate(vx / 50, vy / 50, 0);
        this.GetComponent<SpriteRenderer>().flipX = flipFlag;
    }
}
