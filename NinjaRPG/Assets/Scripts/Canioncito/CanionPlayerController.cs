using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanionPlayerController : MonoBehaviour
{
    
    const float LEFTLIMIT = -7.1f, RIGHTLIMIT = 7.1f;
    float speed = 10f;
    float triggerSpeed = 10f, triggerAngle;
    Vector3 deltaPos, mousePosition;
    public GameObject CanionBallPrefab;



    // Start is called before the first frame update
    void Start()
    {
        deltaPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos.y = deltaPos.z = 0;
        deltaPos = new Vector3(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime;
        transform.Translate(deltaPos);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, 
            LEFTLIMIT, 
            RIGHTLIMIT), transform.position.y);

        mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));    
        deltaPos = mousePosition - gameObject.transform.position;
        triggerAngle = Mathf.Atan(deltaPos.y / deltaPos.x);
        //triggerAngle = Vector3.Angle(transform.position, mousePosition);

        if (deltaPos.x < 0){
            triggerAngle = 90;
        }
        else if (deltaPos.y < 0){
            triggerAngle = 0;
        }

        Debug.Log(Mathf.PingPong(0, 20));
        //
        

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(CanionBallPrefab, transform.position, Quaternion.identity).GetComponent<CanionBallBehaviour>().Shoot(triggerSpeed, triggerAngle);
        }
            
    }
}
