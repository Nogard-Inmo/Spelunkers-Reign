using Unity.VisualScripting;
using UnityEngine;

public class PlayerGunsBase : MonoBehaviour
{
    public bool hasGun = false;
    public GameObject gunPivot;
    public Vector2 mousePos;
    public Transform firePoint;
    public float shootCooldown = 0.5f;
    public float shootCooldownTimer = 0f;

    public LayerMask shootLayerMask;
    public int damage = 10;

    public KeyCode shootKey = KeyCode.Mouse0;


    [SerializeField] private GameObject bulletPrefab;

    //Alex variables
    AnimatePlayer aM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        aM = GetComponent<AnimatePlayer>();
    }


    public virtual void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDir = (mousePos - (Vector2)transform.position).normalized;
            gunPivot.transform.right = aimDir;
        shootCooldownTimer -= Time.deltaTime;
        if (shootCooldownTimer < 0f)
            shootCooldownTimer = 0f;
        
        if(Input.GetKey(shootKey))
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        if (shootCooldownTimer > 0f)
            return;

        shootCooldownTimer = shootCooldown;
        RaycastHit2D shootLine = Physics2D.Raycast(firePoint.position, mousePos - (Vector2)firePoint.position, Mathf.Infinity, shootLayerMask);

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);



        print("shooting:" + shootLine.collider.name);
        if (shootLine.collider != null)
        {
            if (shootLine.collider.CompareTag("Enemy"))
            {
                

                Health targetHealth = shootLine.collider.GetComponent<Health>();

                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(damage);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(firePoint.position, mousePos);
        Debug.DrawRay(firePoint.position, mousePos - (Vector2)firePoint.position, Color.red);
    }
}
