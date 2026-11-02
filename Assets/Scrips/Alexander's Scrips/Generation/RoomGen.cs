using UnityEngine;

public class WorldGen : MonoBehaviour
{
    private void GenerateRooms(Room[] rooms)
    {

    }

    private void CheckRooms()
    {

    }
    private void findOffset()
    {

    }
}

public class Room : MonoBehaviour
{
    public GameObject thisRoom;
    public string roomID;
    public string roomType;
    public int maxAmount;
    [SerializeField] private GameObject[] connectionPoints;
}
