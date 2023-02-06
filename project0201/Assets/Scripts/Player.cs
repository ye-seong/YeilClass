using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject targetObejct;
    public float speed = 1;

    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (targetObejct.transform.position - this.transform.position).normalized;

        float vx = dir.x * -speed;
        float vy = dir.y * -speed;

        rbody.velocity = new Vector2(vx, vy);

        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }
}
