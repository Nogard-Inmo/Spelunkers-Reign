using UnityEngine;

public class Pathways : MonoBehaviour
{
    private GameObject player;
    public RoomGenTwo roomGen;
    public GameObject teleportPoint;
    public GameObject connectedPoint;

    private void Start()
    {
        roomGen = GameObject.FindWithTag("GameController").GetComponent<RoomGenTwo>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = connectedPoint.transform.position;
        }
    }
}
