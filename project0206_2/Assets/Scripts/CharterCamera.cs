using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharterCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        pos.z = -10;
        Camera.main.gameObject.transform.position = pos;
    }
}
