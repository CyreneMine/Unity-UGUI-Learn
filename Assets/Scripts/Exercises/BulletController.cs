
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
