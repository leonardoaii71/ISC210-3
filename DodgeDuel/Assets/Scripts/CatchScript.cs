using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{

    Animator handsAnimator;
    Animator EnemyAnimator;
    public LineRenderer lineRenderer;
    public GameController gameController;

    private void Awake() {
     
        //lineRenderer = GameObject.Find("shooter").GetComponent<LineRenderer>();
        
    }

    private void Start() {
        handsAnimator = GameObject.Find("pivot").GetComponent<Animator>();
        lineRenderer.enabled = false;
    }


    private void OnTriggerEnter(Collider other) {

        other.attachedRigidbody.velocity = Vector3.zero;
        other.transform.SetParent(transform);
        gameController.moving = false;
        other.transform.localPosition = Vector3.zero; 
        handsAnimator.SetTrigger("Catched");
        StartCoroutine("Fade");
    }

        IEnumerator Fade() {
            lineRenderer.enabled = true;
            yield return new WaitForSeconds(1.2f);
            lineRenderer.enabled = false;    
        }
}
