using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    PlayerMovement pM;
    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
    }

}
