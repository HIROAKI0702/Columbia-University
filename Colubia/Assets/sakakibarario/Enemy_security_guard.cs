using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_security_guard : MonoBehaviour
{
    Rigidbody2D rb;

    //�G�̓���
    public float speed = 2.0f;

    //�J�E���g�p
    private float countleftTime  = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
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
        this.transform.localScale = new Vector2(1, 1);
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        yield return new WaitForSeconds(2.0f);
        direction = true;
        countleftTime = 3.0f;
        yield break;
    }
    IEnumerator Moveright()
    {
        this.transform.localScale = new Vector2(-1, 1);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        yield return new WaitForSeconds(2.0f);
        direction = false;
        countrightTime = 3.0f;
        yield break;
    }
}
