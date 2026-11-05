using UnityEngine;

public class Projectilescript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 5f;
    [SerializeField] Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }
}
