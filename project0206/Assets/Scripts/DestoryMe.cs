using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryMe : MonoBehaviour
{
    bool showFlag = false;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            showFlag = true;
        }
        else
        {
            if (showFlag)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
