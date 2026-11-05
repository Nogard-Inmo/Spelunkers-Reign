using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float camSpeed = 12;
    [SerializeField] Vector2 deltaPos;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        deltaPos = player.transform.position - transform.position;
        rb.linearVelocity = deltaPos.normalized * camSpeed;
        if(Mathf.Abs(deltaPos.x) < 0.5)
        {
            rb.linearVelocityX = 0;
        }
        if (Mathf.Abs(deltaPos.y) < 0.5)
        {
            rb.linearVelocityY = 0;
        }
    }
}

