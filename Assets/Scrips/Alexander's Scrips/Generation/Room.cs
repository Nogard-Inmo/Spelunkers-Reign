using UnityEngine;
public class Room : MonoBehaviour
{
    public GameObject thisRoom;
    public string roomID;
    public string roomType;
    public int maxAmount;
    public ConnectionPoint[] connectionPoints;
    GameObject[] connectionPointsObj;
    private void SetValue()
    {
        thisRoom = this.gameObject;
        for (int i = 0; i < connectionPoints.Length; i++)
        {

        }
    }

    private void Update()
    {
        SetValue();
    }
}

public class ConnectionPoint : MonoBehaviour
{
    public GameObject connectionPoint;
    public bool isConnected = false;
}
