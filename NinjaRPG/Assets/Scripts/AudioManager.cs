using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instace;
    public AudioSource HitSound;
    public AudioSource explosion;
    // Start is called before the first frame update

    public enum SoundEffect {
        Explode,
        hit
    }

    private void Awake() {
        Instace = this;
    }

    public void PlaySoundEffect(SoundEffect type){
        switch (type)
        {
            case SoundEffect.hit:
                HitSound.Play();
                break;

            case SoundEffect.Explode:
                explosion.Play();
                break;
                
            default:
                break;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
