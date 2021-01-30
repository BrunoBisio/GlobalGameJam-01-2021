using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    private PlayerController pController;
    // Start is called before the first frame update
    void Start()
    {
        pController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
     if(pController.Spawn != this.gameObject && player.transform.position.x> this.transform.position.x)
        {
            pController.Spawn = this.gameObject;
        }   
    }
}
