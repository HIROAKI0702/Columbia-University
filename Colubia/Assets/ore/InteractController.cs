using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
