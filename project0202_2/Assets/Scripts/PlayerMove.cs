using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject ghost;
    public GameObject treasure;
    public GameObject gameover;
    public GameObject gameclear;

    float speed = 3;

    float vx = 0;
    float vy = 0;

    bool flipFlag = false;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        gameover.SetActive(false);
        gameclear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vy = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
            flipFlag = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
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
        rigid.velocity = new Vector2(vx, vy);

        this.GetComponent<SpriteRenderer>().flipX = flipFlag;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ghost.name)
        {
            gameObject.SetActive(false);
            gameover.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.name == treasure.name)
        {
            treasure.SetActive(false);
            gameclear.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
