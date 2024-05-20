using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LockerController : MonoBehaviour
{
    //  �q�I�u�W�F�N�g�擾�p
    public GameObject LockerF;
    public GameObject LockerVision;
    private bool isStay = false;
    PlayerController PlayerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();

        if (transform.localEulerAngles.z == 180)
        {
            LockerF.transform.localEulerAngles = transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCTRL.isInteract == true && isStay)
        {
            LockerF.SetActive(true);
        }
        else
        {
            LockerF.SetActive(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isStay = true;
        LockerF.SetActive(true);// �擾����obj��\��������
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
        LockerF.SetActive(false);// �擾����obj���\���ɂ���
    }
}
