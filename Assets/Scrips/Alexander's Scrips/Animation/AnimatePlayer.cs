using Unity.Mathematics;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    PlayerMovement pM;
    PlayerGunsBase pGB;
    [SerializeField] Quaternion rota;
    [SerializeField] GameObject pivotArm1, pivotArm2;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    private void Awake()
    {
        pGB = GetComponent<PlayerGunsBase>();
        pM = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();

        pivotArm1 = pGB.gunPivotFront.transform.GetChild(0).gameObject;
        pivotArm2 = pGB.gunPivotBack.transform.GetChild(0).gameObject;
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
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(pM.right))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (pGB.gunPivotFront.transform.rotation.z >= 90)
        {
            pivotArm1.GetComponent<SpriteRenderer>().flipY = false;
        }
        if(pGB.gunPivotBack.transform.rotation.z >= 90)
        {
            pivotArm2.GetComponent<SpriteRenderer>().flipY = false;
        }
        else if (pGB.gunPivotFront.transform.rotation.z < 90)
        {
            pivotArm1.GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (pGB.gunPivotBack.transform.rotation.z < 90)
        {
            pivotArm2.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            pivotArm1.GetComponent<SpriteRenderer>().flipY = false;
            pivotArm2.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    private void Update()
    {
        //rota = pGB.gunPivot.transform.rotation;
        Animate();
    }

}
