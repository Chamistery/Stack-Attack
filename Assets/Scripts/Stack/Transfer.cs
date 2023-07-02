using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    private bool isPos;
    //public bool item;
  //  float x = 0;
    public float Speed = 1;
    public Animator animator;
    private bool throwed;
    public static float vec = 0;
    private int pos = 0;
    public static bool lastVec;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(1, 11);
        pos = 0;
        if (transform.position.x == -8.5f)
            isPos = true;
        else
            isPos = false;
    }
    IEnumerator last()
    {
        lastVec = true;
        yield return new WaitForSeconds(5f);
        lastVec = false;
    }

    // Update is called once per frame
    void Update()
    {
       // x += 0.0005f;
        if (isPos)
        {
            transform.position = new Vector3(transform.position.x + 0.003f * Speed, transform.position.y, 0);//Vector3.MoveTowards(transform.position, new Vector3(20f, transform.position.y,0), Time.deltaTime * Speed);
            if (transform.position.x > 8.48f && !throwed)
            {
                int b = Random.Range(1, 3);
                if (b == 1 && !lastVec)
                {
                    throwing();
                    StartCoroutine(last());
                }
            }
            if (Mathf.Round(transform.position.x )== 12f)
            {
                Destroy(this.gameObject);
                if (!throwed)
                    InstantStack.count--;
            }
            //    item.transform.position = new Vector2(item.transform.position.x + x, item.transform.position.y);
            //    _taker.transform.position = new Vector2(_taker.transform.position.x + x, _taker.transform.position.y);
        }
        else
        {
            transform.position = transform.position = new Vector3(transform.position.x - 0.003f * Speed, transform.position.y, 0);//Vector3.MoveTowards(transform.position, new Vector3(-20f, transform.position.y, 0), Time.deltaTime * Speed);
            if (transform.position.x <= -8f && !throwed)
            {
                int b = Random.Range(1, 3);
                if (b == 1 && !lastVec)
                {
                    throwing();
                    StartCoroutine(last());
                }
            }
            if (Mathf.Round(Mathf.Abs(transform.position.x)) == 12f)
            {
                Destroy(this.gameObject);
                if (!throwed)
                    InstantStack.count--;
            }
        }
        if(Mathf.Abs(transform.position.x - 0.27f) % 1.185f < 0.008f && !throwed)// && transform.position.x != vec)
        {
            pos++;
            if (a != 15)
            {
                //  int a = 0;
                if (vec == 0)
                {
                    if (a == pos)
                        throwing();
                }
                else
                {
                    a--;
                    if (a == pos)
                        throwing();
                }
            }
            else
            {
                if (!lastVec)
                {
                    throwing();
                }
            }
           // throwing();
        }

    }
    void throwing()
    {
        Debug.Log(transform.position.x);
        StartCoroutine(blacklist(transform.position.x));
        animator.SetTrigger("Throw");
        //  Destroy(this.transform.Find("taker(Clone)"));
        this.transform.Find("taker(Clone)").GetComponent<taker>().Delete();
        //  transform.DetachChildren();
        if (this.transform.Find("Iron(Clone)") != null)
        {
            //this.transform.Find("Iron(Clone)").GetComponent<Stone>().isInAir = false;
            this.transform.Find("Iron(Clone)").GetComponent<Stone>().change();
            this.transform.Find("Iron(Clone)").GetComponent<Stone>().inChain = false;
            this.transform.Find("Iron(Clone)").transform.parent = null;
        }
        else if (this.transform.Find("Stone(Clone)") != null)
        {
           // this.transform.Find("Stone(Clone)").GetComponent<Stone>().isInAir = false;
            this.transform.Find("Stone(Clone)").GetComponent<Stone>().change();
            this.transform.Find("Stone(Clone)").GetComponent<Stone>().inChain = false;
            this.transform.Find("Stone(Clone)").transform.parent = null;
        }
        throwed = true;
        InstantStack.count--;
    }
    IEnumerator blacklist(float bVec)
    {
        Debug.Log(bVec);
        vec = bVec;
        yield return new WaitForSeconds(6f);
        vec = 0;

    }
}
