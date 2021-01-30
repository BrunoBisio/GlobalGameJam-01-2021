using UnityEngine;

public class VirtualCameraController : MonoBehaviour
{
    private PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        // Debug.Log("distance to move: " + distanceToMove);
        if (distanceToMove > 0)
		{
            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
            lastPlayerPosition = player.transform.position;
        }
        
    }
}
