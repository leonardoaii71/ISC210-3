using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 0.05f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset;
    }
}
