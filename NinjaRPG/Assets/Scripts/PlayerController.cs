using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float LEFTLIMIT = -7.1f, RIGHTLIMIT = 7.1f;
    float speed = 10f;
    Vector3 deltaPos;
    
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GlobalScripts").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime;
        transform.Translate(deltaPos);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LEFTLIMIT, RIGHTLIMIT), transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameController.SendMessage("IncrementScore");
        AudioManager.Instace.PlaySoundEffect((AudioManager.SoundEffect.hit));
    }

}
