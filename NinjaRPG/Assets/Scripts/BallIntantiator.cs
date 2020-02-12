using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIntantiator : MonoBehaviour
{
    public GameObject BallPrefab;
    const float MINX = -10f, MAXX = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateBall", 0, 1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IntantiateBall(){
        Instantiate(BallPrefab, new Vector3(Random.Range(MINX, MAXX), 6, 0), Quaternion.identity);
    }
}
