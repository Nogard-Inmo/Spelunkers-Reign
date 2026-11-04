using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RoomGenTwo : MonoBehaviour
{
    [SerializeField] RoomManager roomManager;
    [SerializeField] Vector3 currentRoomPos;
    public Room[] roomTypes;
    public Room startRoom;
    public Room currentRoom;
    public bool[,] grid = new bool[1000,1000];
    private int overflow = 0;
    private int overflowDir = 0;
    public int x = 500;
    public int y = 500;
    public int roomAmount;
    
    public int RNGxy()
    {
        return UnityEngine.Random.Range(-1, 1);
    }
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
    public void RoomInstanceReset()
    {
        for (int i = 0; i < roomTypes.Length; i++)
        {
            roomTypes[i].roomInstances = 0;
        }
    }
    public void CreateStartRoom(Room room)
    {
        Instantiate(room, new Vector2(25000,25000), Quaternion.identity);
        grid[500, 500] = true;
    }
    public void GenerateRoom(Room room, Vector2 location, int roomAmount)
    {
        currentRoom = Instantiate(room, location, Quaternion.identity);
        DefineGrid();
        room.roomInstances++;
    }

    public void DefineGrid()
    {
        grid[x,y] = true;
    }

    public int TryDirection()
    {
        // 1 = up, 2 = Right, 3 = Down, 4 = Left
        RetryDir:
        x += RNGxy();
        y += RNGxy();
        Vector2 futureRoom = new Vector2(x * 50, y * 50);
        float deltaX = currentRoom.transform.position.x - futureRoom.x;
        float deltaY = currentRoom.transform.position.y - futureRoom.y;
        if (!grid[x, y])
        {
            if (deltaX > 0)
                return 2;
            else if (deltaX < 0)
                return 4;
            else if (deltaY > 0)
                return 1;
            else if (deltaY < 0)
                return 3;
                overflowDir++;
        }
        else if (overflowDir > 20)
        {
            overflowDir = 0;
            return 5;
        }
        goto RetryDir;
    }
    public Vector2 FindPosition()
    {
        Vector2 nextRoomPos = currentRoom.transform.position;
        switch (TryDirection())
        {
            case 1:
                return nextRoomPos = new Vector2(currentRoom.transform.position.x, 50 * y);
            case 2:
                return nextRoomPos = new Vector2(50 * x, currentRoom.transform.position.y);
            case 3:
                return nextRoomPos = new Vector2(currentRoom.transform.position.x, 50 * y);
            case 4:
                return nextRoomPos = new Vector2(50 * x, currentRoom.transform.position.y);
            case 5:
                return nextRoomPos = new Vector2(0, 0);
        }
            
        return new Vector2(0,0);
    }
    public void WholeMapGeneration(int roomAmount)
    {
        CreateStartRoom(startRoom);
        for (int i = 0; i < roomAmount; i++)
        {
            GenerateRoom(roomTypes[RoomPicker(roomTypes)], FindPosition(), roomAmount);
        }
    }

    private void Start()
    {
        roomTypes = roomManager.roomTypes;
        currentRoom = startRoom;
        currentRoomPos = currentRoom.transform.position;
        WholeMapGeneration(roomAmount);
        RoomInstanceReset();
    }
}
