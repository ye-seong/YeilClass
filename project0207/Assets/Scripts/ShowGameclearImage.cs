using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameclearImage : MonoBehaviour
{
    public int End = 0;

    // Update is called once per frame
    void Update()
    {
        End = Ending.ending;

        if (End == 1)
        {
            GetComponent<Image>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
        }
    }
}
