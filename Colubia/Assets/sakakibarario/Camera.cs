using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        //Player�@�̃Q�[���I�u�W�F�N�g�𓾂�
        player = GameObject.FindGameObjectWithTag("Player");

        transform.position = new Vector3(player.transform.position.x,  transform.up.y*-2.0f, transform.position.z);
    }
}
