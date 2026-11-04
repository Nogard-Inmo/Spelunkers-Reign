using System.Collections.Generic;
using UnityEngine;
public class Room : MonoBehaviour
{
    public GameObject thisRoom;
    public string roomID;
    public string roomType;
    public int roomInstances;
    public int maxAmount;
    private void SetValue()
    {
        thisRoom = this.gameObject;
    }

    private void Start()
    {
        SetValue();
    }
}
