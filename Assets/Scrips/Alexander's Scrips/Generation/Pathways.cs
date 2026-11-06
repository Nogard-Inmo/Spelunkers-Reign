using UnityEngine;

public class Pathways : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    public RoomGenTwo roomGen;
    public GameObject teleportPoint;
    public GameObject connectedPoint;

    private void Start()
    {
        try
        {
            //roomGen = GameObject.FindWithTag("GameController").GetComponent<RoomGenTwo>();
            player = GameObject.FindWithTag("Player");
            cam = GameObject.FindWithTag("MainCamera");
        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Should telelport");
            player.transform.position = connectedPoint.transform.position;
            cam.transform.position = new Vector3(connectedPoint.transform.position.x, connectedPoint.transform.position.y, -10);
        }
    }
}
