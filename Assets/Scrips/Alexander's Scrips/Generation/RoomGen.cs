using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public Room currentRoom;
    public Room[] roomTypes;
    public int roomAmount;
    [SerializeField] Room nextRoom;
    [SerializeField] Vector3 roomSize;


    private void GenerateRoomsPreReq(Room room, Vector3 offset, int roomAmount)
    {
        for (int i = 1; i < roomAmount; i++)
        {
            Instantiate(room, offset, Quaternion.identity);
        }
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

    public void GenerateRooms(Room currentRoom, int roomAmount)
    {
        nextRoom = NextRoom(roomTypes);
      /*  GenerateRoomsPreReq(
            nextRoom,
            offset,
            roomAmount   
            );*/
    }
    private void Start()
    {
        GenerateRooms(currentRoom, 4);
    }
}

