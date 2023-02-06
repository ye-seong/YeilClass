using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //bool fCollsion = false;
    float speed = 1; //speed는 1로 할당
    Rigidbody2D rigid; //Rigidbody2D를 rigid라고 설정

    //public GameObject gotarget; //gotarget은 따로 설정
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        rigid = GetComponent<Rigidbody2D>(); //rigid는 Rigidbody2D 컴포넌트
        rigid.gravityScale = 0; //gravityscale은 0으로 고정
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation; //회전하지 않음
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0); //Ghost는 가로로 이동한다
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed; //충돌한다면 1씩 이동하던 것이 -1씩 이동하는 것으로 바뀐다
        this.GetComponent<SpriteRenderer>().flipX = (speed < 0); //방향이 바뀌면 이미지 뒤집기

        //if (collision.gameObject.name == "LBlock") //충돌한 오브젝트 이름이 LBlock 이라면
        //{
        //    Time.timeScale = 0; //Ghost는 멈춘다
        //}

        //if (collision.gameObject.name == gotarget.name) //충돌한 오브젝트 이름과 gotarget 이름이 같으면
        //{
        //    GameObject _gotarget = GameObject.Find(collision.gameObject.name); //_gotarget은 gotarget을 찾은 것
        //    if (_gotarget != null) //충돌한 오브젝트 (gotarget) 가 비어있지 않다면, 즉 존재하고 있다면
        //    {
        //        _gotarget.SetActive(false); //gotarget은 사라진다 (false)
        //    }
        //}

        if (collision.gameObject.tag == "block")
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
            Vector2 gameoverposition = this.gameObject.transform.position;
            gameover.transform.position = new Vector2(gameoverposition.x, 1);
        }
    }
}
