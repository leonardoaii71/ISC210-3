using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool shot;
    private Vector3 deltaPos;
    public GameObject _ball;
    public float Speed = 10f;
    public float LeftLimit = -1.9f, RightLimit = 1.9f;
    public GameController gameController;
    
    public GameObject lftHand;
    public GameObject rghtHand;
    
    // Update is called once per frame
    void Update()
    {
     if(gameController.moving) { 
     float desde, hasta;

        desde = rghtHand.transform.position.x < _ball.transform.position.x ? 
                rghtHand.transform.position.x : _ball.transform.position.x;

        hasta = rghtHand.transform.position.x > _ball.transform.position.x ? 
                rghtHand.transform.position.x : _ball.transform.position.x;

        transform.position = new Vector3(Mathf.Clamp(Mathf.Lerp(desde, hasta, Random.Range(.2f, .1f)), LeftLimit, RightLimit),
                                        transform.position.y, 
                                        transform.position.z); 
     }         

    }
}
