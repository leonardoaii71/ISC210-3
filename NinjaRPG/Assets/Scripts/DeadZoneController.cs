using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeadZoneController : MonoBehaviour
{
    // Start is called before the first frame update
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GlobalScripts").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameController.SendMessage("DecrementLive");
        AudioManager.Instace.PlaySoundEffect((AudioManager.SoundEffect.Explode));
    }
}
