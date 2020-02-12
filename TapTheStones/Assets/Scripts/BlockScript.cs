using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GlobalScript globalScript;
    public bool isDestroyable = false;
    //public bool outCast = false;

    // Start is called before the first frame update
    void Start()
    {
        globalScript = GameObject.Find("MainScripts").GetComponent<GlobalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (isDestroyable){
            if (other.gameObject.tag == gameObject.tag)
                other.GetComponent<BlockScript>().isDestroyable = true;  
                //outCast = true;
            Destroy(gameObject);
        }
    }

    private void OnMouseDown() {
        globalScript.LastTapped = gameObject;
        isDestroyable = true;
        
    }
}
