using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunGunIconController : MonoBehaviour
{
    PlayerController player;
    Image img;

    public int count = 10;
    public int countTime;
    float timer;
    bool startcooltime = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.CanUseStungun)
        {
            if(startcooltime)
            {
                img.fillAmount = 1.0f;
                startcooltime = false;
            }

            img.fillAmount -= 1.0f / countTime * Time.deltaTime;
            if(img.fillAmount <= 0 )
                player.CanUseStungun = true;
        }
        else
        {
            Debug.Log(img.fillAmount);
            img.fillAmount = 0.0f;
            startcooltime = true;
        }
            
    }
}
