using Unity.VisualScripting;
using UnityEngine;

public class RoomGenTwo : MonoBehaviour
{
    [SerializeField] Room[] roomTypes;
    public Room startRoom;
    public Room currentRoom;
    public Room nextRoom;
    public Vector2 position;
    public bool[,] grid;
    public int x;
    public int y;
    public int roomAmount;

    private int RNGOne()
    {
        return UnityEngine.Random.Range(-1,1);
    }
    public int RoomPicker(Room[] roomTypes)
    {
        int roomType = UnityEngine.Random.Range(1, roomTypes.Length);
        return roomType;
    }
    public void SetGridLocation()
    {
        grid[x, y] = grid[x+RNGOne(), y+RNGOne()];

        if (!grid[x, y])
        {
            grid[x, y] = true;
        }
        position.y = y * 50;
        position.x = x * 50;
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
            GenerateRoom(roomTypes[RoomPicker(roomTypes)], position, roomAmount);
        }
    }


    private void Start()
    {
        WholeMapGeneration(roomAmount);
    }
}
