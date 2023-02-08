using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator animator;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;   //착지할 수 있는 레이어
    bool goJump = false;            //점프 개시 플래그
    bool onGround = false;          //지면에 서 있는 플래그

    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string clearAnime = "PlayerClear";
    public string overAnime = "PlayerOver";
    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        animator = this.GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;

        gameState = "Playing";
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameState != "playing")
        //{
        //    return;
        //}

        axisH = Input.GetAxisRaw("Horizontal");

        //플립
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        //점프
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        //if (gameState != "playing")
        //{
        //    return;
        //}

        onGround = Physics2D.Linecast(transform.position, 
                                          transform.position - (transform.up * 0.1f), 
                                          groundLayer);
        if (onGround || axisH != 0)
        {
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }

        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        if (onGround)
        {
            if (axisH == 0)
            {
                nowAnime = stopAnime;
            }
            else
            {
                nowAnime = moveAnime;
            }
        }
        else
        {
            nowAnime = jumpAnime;
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
            gameState = "gameClear";
            GameStop();
        }

        if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
    }


    void Dead()
    {
        animator.Play(overAnime);
        gameState = "gameOver";
        GameStop();

        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void Goal()
    {
        animator.Play(clearAnime);        
    }

    void GameStop()
    {
        rbody.velocity = new Vector2(0, 0);
    }

    public void Jump()
    {
        goJump = true;
    }
}
