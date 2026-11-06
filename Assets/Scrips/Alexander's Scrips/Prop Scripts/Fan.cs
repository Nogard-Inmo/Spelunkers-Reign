using UnityEngine;
using UnityEngine.UIElements;

public class Fan : MonoBehaviour
{
    [SerializeField] bool isBlowingPlayer;
    [SerializeField, Range(10, 50)] float fanStrength;
    [SerializeField] Vector3 blowAngle;
    [SerializeField] Rigidbody2D effectedObject;
    [SerializeField] GameObject fanBlowPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isBlowingPlayer = true;
        effectedObject = collision.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isBlowingPlayer = false;
        effectedObject = null;
    }
    private void Start()
    {
        fanBlowPoint = transform.GetChild(0).gameObject;
        blowAngle = fanBlowPoint.transform.position - transform.position;

    }
    private void Update()
    {
        if (isBlowingPlayer)
        {
            effectedObject.AddForceY(blowAngle.y * 0.005f * fanStrength, ForceMode2D.Impulse);
            effectedObject.AddForceX(blowAngle.x * fanStrength, ForceMode2D.Force);
        }
    }
}
