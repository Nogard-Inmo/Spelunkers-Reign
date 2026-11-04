using System.Collections.Generic;
using UnityEngine;
public class Room : MonoBehaviour
{
    public GameObject thisRoom;
    public List<GameObject> pathways;
    public string roomID;
    public string roomType;
    public int roomInstances;
    public int maxAmount;
    private void SetValue()
    {
        pathways.Add(GameObject.FindWithTag("UpPoint"));
        pathways.Add(GameObject.FindWithTag("RightPoint"));
        pathways.Add(GameObject.FindWithTag("DownPoint"));
        pathways.Add(GameObject.FindWithTag("LeftPoint"));
        thisRoom = this.gameObject;
    }

    private void Start()
    {
        SetValue();
    }
}
