     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mov = new Vector3(Player.transform.position.x, Player.transform.position.y, -5);
        this.gameObject.transform.position = mov;
    }
}
