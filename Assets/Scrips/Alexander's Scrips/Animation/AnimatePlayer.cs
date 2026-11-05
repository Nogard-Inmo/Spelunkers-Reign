using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    PlayerMovement pM;
    PlayerGunsBase pGB;
    [SerializeField] GameObject pivotArm1, pivotArm2;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    public bool isFacingLeft = false;
    private void Awake()
    {
        pGB = GetComponent<PlayerGunsBase>();
        pM = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    
    private void Animate()
    {
        speed = Mathf.Abs(pM.rb.linearVelocityX);
        animator.SetFloat("Speed", speed);
        FlipPlayer();
    }
    private void FlipPlayer()
    {
        if (Input.GetKey(pM.left))
        {
            isFacingLeft = true;
        }
        if (Input.GetKey(pM.right))
        {
            isFacingLeft = false;
        }
        if (isFacingLeft)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (!isFacingLeft)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void Update()
    {
        Animate();
    }

}
