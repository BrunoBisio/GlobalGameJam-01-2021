using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraO;
    private float xDistance;
    // Start is called before the first frame update
    void Start()
    {
        xDistance = cameraO.transform.position.x - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x + (cameraO.transform.position.x - this.transform.position.x - xDistance), this.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(player.Equals(collision.gameObject))
        {
            //player.GetComponent<PlayerController>().Die();
        }
    }
}
