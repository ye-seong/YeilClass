using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScore : MonoBehaviour
{
    public GameObject score_1;
    public GameObject score_2;
    public GameObject score_3;
    public GameObject score_4;
    public GameObject score_5;

    public GameObject Gameclear;
    public GameObject Gameover;

    float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        score_1.SetActive(false);
        score_2.SetActive(false);
        score_3.SetActive(false);
        score_4.SetActive(false);
        score_5.SetActive(false);

        Gameclear.SetActive(false);
        Gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "disitem")
        {
            Gameover.SetActive(true); Debug.Log("°ÔÀÓ¿À¹ö!");
            Time.timeScale = 0;
        }

        if (collision.gameObject.tag == "item")
        {
            count += 1;
        }

        if (count == 1) { score_1.SetActive(true); Debug.Log("1Á¡È¹µæ!"); }
        if (count == 2) { score_2.SetActive(true); Debug.Log("2Á¡È¹µæ!"); }
        if (count == 3) { score_3.SetActive(true); Debug.Log("3Á¡È¹µæ!"); }
        if (count == 4) { score_4.SetActive(true); Debug.Log("4Á¡È¹µæ!"); }
        if (count == 5) { score_5.SetActive(true); Gameclear.SetActive(true); Time.timeScale = 0; Debug.Log("5Á¡È¹µæ!"); }
    }
}
