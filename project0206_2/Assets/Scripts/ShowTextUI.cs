using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTextUI : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Counter.value == 0)
        {
            GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<TMP_Text>().enabled = true;
            GetComponent<TMP_Text>().text = Counter.value.ToString();
        }
        
    }
}
