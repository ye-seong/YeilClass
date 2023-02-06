using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public string targetGoName;
    public float speed = 1;

    public GameObject targetObject;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("Player");

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;

        float vx = dir.x * speed;
        float vy = dir.y * speed;

        rigidBody.velocity = new Vector2(vx, vy);

        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }
}
