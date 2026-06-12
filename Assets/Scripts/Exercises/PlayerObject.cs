using System;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public AudioClip clip;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }
    }
    
    public void Fire()
    {
        Instantiate(Resources.Load<GameObject>("Bullet"),transform.position,transform.rotation);
        if (MusicData.SoundIsOpen)
        {
            FireAudio();
        }
    }
    private void FireAudio()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource, 0.8f);
    }
}
