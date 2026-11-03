using Unity.VisualScripting;
using UnityEngine;

public class RoomGenTwo : MonoBehaviour
{
    [SerializeField] Room[] roomTypes;
    public Room startRoom;
    public Room currentRoom;
    public Room nextRoom;
    public Vector3 position;
    public int roomAmount;

    public int RoomPicker(Room[] roomTypes)
    {
        int roomType = UnityEngine.Random.Range(1, roomTypes.Length);
        return roomType;
    }
    /*public Vector3 FindPostion()
    {

    }*/
    public void CreateStartRoom(Room room)
    {
        Instantiate(room, new Vector3(0,0,0), Quaternion.identity);
    }
    public void GenerateRoom(Room room, Vector3 location, int roomAmount)
    {
        Instantiate(room, location, Quaternion.identity);
    }
    public void WholeMapGeneration(Vector3 location, int roomAmount)
    {
        CreateStartRoom(startRoom);
        for (int i = 0; i < roomTypes.Length; i++)
        {
            GenerateRoom(roomTypes[RoomPicker(roomTypes)], location, roomAmount);
        }
    }


    private void Start()
    {
        WholeMapGeneration(position, roomAmount);
    }
}
