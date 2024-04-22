using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_security_guard : MonoBehaviour
{
    Rigidbody2D rb;

    //�G�̓���
    public float speed = 5.0f;

    //�J�E���g�p
    private float countleftTime  = 5.0f;   //������
    private float countrightTime = 5.0f;   //�E����
    private bool direction = false;        //true�͉E����


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    private void FixedUpdate()
    {
        if (direction)
        {
            countrightTime -= Time.deltaTime; //�J�E���g�A�b�v

            if (countrightTime < 0)
            {
                StartCoroutine(Moveright());
            }
        }
        else
        {
            countleftTime -= Time.deltaTime;  //�J�E���g�A�b�v

            if (countleftTime < 0)
            {
                StartCoroutine(Moveleft());
            }
        }
      
    }
    IEnumerator Moveleft()
    {
        Debug.Log("Active");
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        yield return new WaitForSeconds(0.1f);
        direction = true;
        countleftTime = 5.0f;
        yield break;
    }
    IEnumerator Moveright()
    {
        Debug.Log("Active!");
        rb.velocity = new Vector2(speed, rb.velocity.y);
        yield return new WaitForSeconds(0.1f);
        direction = false;
        countrightTime = 5.0f;
        yield break;
    }
}
