using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float xposition;
    private float length;
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xposition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distaneMoved = cam.transform.position.x * (1 - parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(xposition + distanceToMove, transform.position.y);

        if (distaneMoved > xposition + length)
            xposition += length;
        else if (distaneMoved < xposition - length)
            xposition -= length;
    }
}
