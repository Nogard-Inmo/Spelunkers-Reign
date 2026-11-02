using System;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public Room currentRoom;
    public Room[] roomTypes;
    public int roomAmount;

    [SerializeField] Vector3 roomSize;


    private void GenerateRoomsPreReq(Room room, Vector3 offset, int roomAmount)
    {
        for (int i = 0; i < roomAmount; i++)
        {
            Instantiate(room, offset, Quaternion.identity);
        }
    }
    private int FindConnectionPoint(Room room)
    {
        bool hasFound = false;
        int overflow = 20;
        int iteration = 0;
        while (hasFound)
        {
            iteration++;
            int connection = UnityEngine.Random.Range(0, room.connectionPoints.Length);
            if (!room.connectionPoints[connection].isConnected)
            {
                hasFound = true;
                return connection;
            }
            if (iteration == overflow)
            {
                goto NoneFound;
            }
        }
        NoneFound:
        return 0;
    }
    private Room NextRoom(Room[] roomTypes)
    {
        int roomType = UnityEngine.Random.Range(0, roomTypes.Length);
        return roomTypes[roomType];
    }
    private Vector3 FindOffset(Room currentRoom, Room nextRoom, int connectorIn, int connectorOut)
    {
        Vector3 originPoint = currentRoom.connectionPoints[connectorIn].transform.position;
        Vector3 connectedPoint = nextRoom.connectionPoints[connectorOut].transform.position;
        return originPoint - connectedPoint;
    }
    public void GenerateRooms(Room currentRoom, int roomAmount)
    {
        Room nextroom = NextRoom(roomTypes);
        GenerateRoomsPreReq(
            nextroom,
            FindOffset(
                currentRoom,
                nextroom,
                FindConnectionPoint(currentRoom),
                FindConnectionPoint(nextroom)
             ),
            roomAmount   
            );
    }

    private void Start()
    {
        GenerateRooms(currentRoom, 0);
    }
}

