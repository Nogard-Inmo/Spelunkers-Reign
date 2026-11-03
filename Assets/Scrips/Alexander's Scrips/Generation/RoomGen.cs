using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public Room currentRoom;
    public Room[] roomTypes;
    public int roomAmount;

    public Vector3 offset;
    [SerializeField] Room nextRoom;
    [SerializeField] Vector3 roomSize;


    private void GenerateRoomsPreReq(Room room, Vector3 offset, int roomAmount)
    {
        for (int i = 1; i < roomAmount; i++)
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
            int connection = UnityEngine.Random.Range(0, room.connectionPoints.Count);
            print("connection point status: " + room.connectionPoints[connection].isConnected);
            if (room.connectionPoints[connection].isConnected == false)
            {
                print("Found Connection point, room: " + room.roomType + " " + connection);
                hasFound = true;
                return connection;
            }
            if (iteration == overflow)
            {
                goto NoneFound;
            }
        }
    NoneFound:
        print("Couldn't find connection point");
        return 0;
    }
    private Room NextRoom(Room[] roomTypes)
    {
        int roomType = UnityEngine.Random.Range(0, roomTypes.Length);
        print("Before room gen");
        Room room = Instantiate(roomTypes[roomType]);
        print("After room gen");
        print(room.gameObject.transform.position);
        return room;
    }
    private Vector3 FindOffset(Room currentRoom, Room nextRoom, int connectorIn, int connectorOut)
    {
        Vector3 originPoint = currentRoom.connectionPoints[connectorIn].connectionPoint.transform.position;
        Vector3 connectedPoint = nextRoom.connectionPoints[connectorOut].connectionPoint.transform.position;
        return originPoint - connectedPoint;
    }
    public void GenerateRooms(Room currentRoom, int roomAmount)
    {
        nextRoom = NextRoom(roomTypes);
        StartCoroutine(
            WaitForOffset(
                currentRoom, 
                nextRoom, 
                FindConnectionPoint(currentRoom), 
                FindConnectionPoint(nextRoom)
                ));
        GenerateRoomsPreReq(
            nextRoom,
            offset,
            roomAmount   
            );
    }


    public IEnumerator WaitForOffset(Room currentRoom, Room nextRoom, int connectorIn, int connectorOut)
    {
        yield return new WaitForEndOfFrame();
        offset = FindOffset(currentRoom, nextRoom, connectorIn, connectorOut);
    }

    private void Start()
    {
        GenerateRooms(currentRoom, 4);
    }
}

