using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static int value;

    public int startCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        value = startCount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            value += 1;
        }
    }
}
