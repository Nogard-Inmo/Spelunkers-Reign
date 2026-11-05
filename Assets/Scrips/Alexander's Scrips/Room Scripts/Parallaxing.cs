using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    [Header("Parallax Layers")]
    [SerializeField] GameObject centerPoint;
    [SerializeField] GameObject collisionLayer;
    [SerializeField] GameObject parallaxLayer1;
    [SerializeField] GameObject parallaxLayer2;
    [SerializeField] GameObject foreground;
    [SerializeField] GameObject backdrop;
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;

    private void Start()
    {
        try
        {
            collisionLayer.transform.position = centerPoint.transform.position;
            foreground.transform.position = centerPoint.transform.position;
            background1.transform.position = centerPoint.transform.position;
            background2.transform.position = centerPoint.transform.position;
            parallaxLayer1.transform.position = centerPoint.transform.position;
            parallaxLayer2.transform.position = centerPoint.transform.position;
            backdrop.transform.position = centerPoint.transform.position;
        }
        catch
        {
            print("Not all layers are inputed, no need to worry");
        }
    }

}
