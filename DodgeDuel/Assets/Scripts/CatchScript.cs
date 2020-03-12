using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{

    Animator playerAnimator;
    private void Start() {
        playerAnimator = GameObject.Find("pivot").GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other) {

        other.attachedRigidbody.velocity = Vector3.zero;
        other.transform.SetParent(transform);
        other.transform.localPosition = Vector3.zero; 
        playerAnimator.SetTrigger("Catched");
        //playerAnimator.pa
        
    }
}
