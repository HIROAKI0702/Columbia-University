using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class LockerController : MonoBehaviour
{
    //  �q�I�u�W�F�N�g�擾�p
    public GameObject childObj;

    PlayerController PlayerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerCTRL.LockerVision==true)
            childObj.SetActive(true);// �擾����obj��\��������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            childObj.SetActive(false);// �擾����obj���\���ɂ���
    }
}
