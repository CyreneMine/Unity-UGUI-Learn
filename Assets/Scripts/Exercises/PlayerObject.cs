using System;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float roundSpeed = 10f;
    public AudioClip clip;
    public static float hp = 10f;
    public Vector3 nowDirection;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }

        if (nowDirection!=Vector3.zero)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nowDirection), roundSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector2 direction)
    {
        nowDirection.x = direction.x;
        nowDirection.y = 0;
        nowDirection.z = direction.y;
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
        audioSource.volume = MusicData.SoundVolume;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource, 0.8f);
    }
}
