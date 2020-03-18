using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 deltaPos;
    public float Speed = 10f;
    public float LeftLimit = -1.9f, RightLimit = 1.9f;
  

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0f); 
        transform.Translate(deltaPos);
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
                transform.position.y, 
                transform.position.z);
    }

}
