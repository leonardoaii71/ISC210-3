using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECatchScript : MonoBehaviour
{

    Animator handsAnimator;
    Vector3 shotDirection;
    GameObject ball;
    public GameObject Player;
    public GameController gameController;



    private void Start() {

        handsAnimator = GameObject.Find("epivot").GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other) {

        other.attachedRigidbody.velocity = Vector3.zero;
        other.transform.SetParent(transform);
        ball = other.gameObject;
        gameController.moving = false;
        other.transform.localPosition = Vector3.zero; 
        handsAnimator.SetTrigger("shootBack");       
        if(transform.GetChild(0))
            StartCoroutine("shoot");
 
    }

    IEnumerator shoot(){
        yield return new WaitForSeconds(0.5f);
        shotDirection =  Player.transform.position - transform.position;
        shotDirection.Normalize();
        ball.gameObject.SetActive(true);
        ball.GetComponent<Rigidbody>().velocity = shotDirection * 10f;
        //gameController.moving = true;
    }

}
