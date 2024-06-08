using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    //  �q�I�u�W�F�N�g�擾�p
    public GameObject SafeF;
    private bool isStay = false;
    PlayerController PlayerCTRL;
    void Start()
    {
        PlayerCTRL = GameObject.Find("Player").GetComponent<PlayerController>();

        if (transform.localEulerAngles.z == 180)
        {
            SafeF.transform.localEulerAngles = transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCTRL.CanInteract == true && isStay)
        {
            SafeF.SetActive(true);
        }
        else
        {
            SafeF.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isStay = true;
            SafeF.SetActive(true);// �擾����obj��\��������
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isStay = false;
            SafeF.SetActive(false);// �擾����obj���\���ɂ���
        }
    }

}
