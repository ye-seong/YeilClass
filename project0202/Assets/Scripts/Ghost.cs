using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //bool fCollsion = false;
    float speed = 1; //speed�� 1�� �Ҵ�
    Rigidbody2D rigid; //Rigidbody2D�� rigid��� ����

    //public GameObject gotarget; //gotarget�� ���� ����
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        rigid = GetComponent<Rigidbody2D>(); //rigid�� Rigidbody2D ������Ʈ
        rigid.gravityScale = 0; //gravityscale�� 0���� ����
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation; //ȸ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0); //Ghost�� ���η� �̵��Ѵ�
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed; //�浹�Ѵٸ� 1�� �̵��ϴ� ���� -1�� �̵��ϴ� ������ �ٲ��
        this.GetComponent<SpriteRenderer>().flipX = (speed < 0); //������ �ٲ�� �̹��� ������

        //if (collision.gameObject.name == "LBlock") //�浹�� ������Ʈ �̸��� LBlock �̶��
        //{
        //    Time.timeScale = 0; //Ghost�� �����
        //}

        //if (collision.gameObject.name == gotarget.name) //�浹�� ������Ʈ �̸��� gotarget �̸��� ������
        //{
        //    GameObject _gotarget = GameObject.Find(collision.gameObject.name); //_gotarget�� gotarget�� ã�� ��
        //    if (_gotarget != null) //�浹�� ������Ʈ (gotarget) �� ������� �ʴٸ�, �� �����ϰ� �ִٸ�
        //    {
        //        _gotarget.SetActive(false); //gotarget�� ������� (false)
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
