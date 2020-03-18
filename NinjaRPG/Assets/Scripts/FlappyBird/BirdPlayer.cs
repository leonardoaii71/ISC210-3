using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
    public float speed = 0.1f;
    float velocity, Viy = 0;
    AudioSource audioSource;
    Vector3 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Componente X
        deltaPos.x += speed * Time.deltaTime;
        Viy += Physics.gravity.y * Time.deltaTime;

        deltaPos.y = Viy * Time.deltaTime + ( Physics.gravity.y  * Mathf.Pow(Time.deltaTime, 2) / 2);
        //Componente Y
        //transform.position = new Vector3 (transform.position.x, Viy * Time.deltaTime + ( Physics.gravity.y  * Mathf.Pow(Time.deltaTime, 2) / 2));
        
        if (Input.GetMouseButtonDown(0))
        {   Viy = 10f;
            StartCoroutine("decelerate");
            audioSource.Play();
        }
        Debug.Log(Viy);
        Debug.Log(deltaPos);

        transform.Translate(deltaPos);
        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 5f, -3.25f));
        
    }

    IEnumerator decelerate(){
        while(Viy > 0){
            Viy --;
            yield return new WaitForSeconds(.2f);
        }
    }

}
