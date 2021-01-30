using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    private PlayerController pController;
    private float xDistance;
    // Start is called before the first frame update
    void Start()
    {
        //pController = player.GetComponent<PlayerController>();
        xDistance = player.transform.position.x - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = (player.transform.position.x - this.transform.position.x - xDistance);
        if(movement > 0)
        {
            this.transform.position = new Vector2(this.transform.position.x + movement, this.transform.position.y);
        }
        
        /*
        if (pController.Spawn != this.gameObject && player.transform.position.x> this.transform.position.x)
        {
            pController.Spawn = this.gameObject;
        } */  
    }
}
