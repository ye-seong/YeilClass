using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public static int ending = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Counter.value == 3)
        {
            //Debug.Log("키를 3개 모두 모았습니다!");

            if(collision.gameObject.tag == "Goal")
            {
                //Debug.Log("게임클리어!");
                ending = 1;
                Time.timeScale = 0;
            }
        }

        if(collision.gameObject.tag == "enemy")
        {
            //Debug.Log("게임오버!");
            ending = 2;
            Time.timeScale = 0;
            
        }
    }
}
