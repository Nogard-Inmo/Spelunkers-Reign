using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RoomGenTwo : MonoBehaviour
{
    [SerializeField] RoomManager roomManager;
    public Room[] roomTypes;
    public Room startRoom;
    public int overflow = 0;
    public Vector2 position;
    public int x;
    public int roomAmount;
    //public 
    public int RoomPicker(Room[] roomTypes)
    {
    Retry:
        overflow++;
        int roomType = UnityEngine.Random.Range(1, roomTypes.Length);
        if (roomTypes[roomType].maxAmount >= roomTypes[roomType].roomInstances)
            return roomType;
        else if (overflow < 20)
        {
            overflow = 0;
            return 0;
        }
        else
            goto Retry;
    }
    public void CreateStartRoom(Room room)
    {
        Instantiate(room, new Vector3(0,0,0), Quaternion.identity);
    }
    public void GenerateRoom(Room room, Vector2 location, int roomAmount)
    {
        Instantiate(room, location, Quaternion.identity);
        room.roomInstances++;
    }
    public void WholeMapGeneration(int roomAmount)
    {
        CreateStartRoom(startRoom);
        for (int i = 0; i < roomAmount; i++)
        {
            x++;
            position.x = x * 50;
            GenerateRoom(roomTypes[RoomPicker(roomTypes)], position, roomAmount);
        }
    }


    private void Start()
    {
        roomTypes = roomManager.roomTypes;
        WholeMapGeneration(roomAmount);
    }
}
