using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreatePrefab2 : MonoBehaviour
{
    public GameObject newPrefab;
    public float startSec = 2.0f;
    public float intervalSec = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreatePrefab", startSec, intervalSec); //2초 뒤 실행되고 1초마다 반복
    }

    void CreatePrefab()
    {
        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;

        Vector3 newPos = this.transform.position;
        newPos.x += Random.Range(-area.x/2, area.x/2);
        newPos.z = -5;

        GameObject newGO = Instantiate(newPrefab) as GameObject;
        newGO.transform.position = newPos;
    }
}
