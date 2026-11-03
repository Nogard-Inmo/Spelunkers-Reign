using Unity.VisualScripting;
using UnityEngine;

public class RoomGenTwo : MonoBehaviour
{
    [SerializeField] Room[] roomTypes;
    public Room startRoom;
    public Room currentRoom;
    public Room nextRoom;
    public Vector2 grid;
    public int x;
    public int y;
    public int roomAmount;

    public int RoomPicker(Room[] roomTypes)
    {
        int roomType = UnityEngine.Random.Range(1, roomTypes.Length);
        return roomType;
    }
    public void SetGridLocation()
    {
        x++;
        y++;
        grid.y = y * 50;
        grid.x = x * 50;
    }
    public void CreateStartRoom(Room room)
    {
        Instantiate(room, new Vector3(0,0,0), Quaternion.identity);
    }
    public void GenerateRoom(Room room, Vector2 location, int roomAmount)
    {
        Instantiate(room, location, Quaternion.identity);
    }
    public void WholeMapGeneration(int roomAmount)
    {
        CreateStartRoom(startRoom);
        for (int i = 0; i < roomAmount; i++)
        {
            SetGridLocation();
            GenerateRoom(roomTypes[RoomPicker(roomTypes)], grid, roomAmount);
        }
    }


    private void Start()
    {
        WholeMapGeneration(roomAmount);
    }
}
