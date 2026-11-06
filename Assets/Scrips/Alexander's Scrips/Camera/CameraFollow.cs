using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float camSpeed = 12;
    [SerializeField] Vector2 deltaPos;
    [SerializeField] float xOffset, yOffset;
    [SerializeField, Range(0.05f,1)] float cameraMargin;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        deltaPos = player.transform.position - transform.position + new Vector3(xOffset, yOffset);
        rb.linearVelocity = deltaPos.normalized * camSpeed;
        if(Mathf.Abs(deltaPos.x) < cameraMargin)
        {
            rb.linearVelocityX = 0;
        }
        if (Mathf.Abs(deltaPos.y) < cameraMargin)
        {
            rb.linearVelocityY = 0;
        }
    }
}

