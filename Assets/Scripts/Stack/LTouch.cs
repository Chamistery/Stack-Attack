using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTouch : MonoBehaviour
{
    public bool left;
    public GameObject par;
    public bool touch;
    public bool isStat;
    public bool onStack;
    //  public bool toFloor;
    // private bool ltomove;
    // private bool resp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !par.GetComponent<Stone>().isInAir && !isStat)
        {
            transform.parent.transform.Find("r").GetComponent<RTouch>().right = true;
            left = true;
            Debug.Log(0);
        }
        else if (collision.tag == "Player" && par.GetComponent<Stone>().isInAir && !isStat)
        {
            left = true;
        }
        //else if (collision.tag == "Player" && !par.GetComponent<Stone>().isInAir && isStat)
        //{
        //    left = true;
        //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);

        //}
        if (collision.tag == "StackBack")// && !collision.GetComponent<Stone>().isInAir)// || collision.tag == "Floor")
        {
            touch = true;
        }
        if (collision.tag == "Floor" && !par.GetComponent<Stone>().isInAir)
        {
            par.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
           // toFloor = true;
        }
        //if(collision.tag != "Respawn")
        //{
        //    ltomove = false;
        //}
        //else
        //{
        //    ltomove = true;
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            left = false;
            Debug.Log(1);
        }
        //if (collision.tag == "StackBack")
        //{
        //    touch = false;
        //}
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Stack")
    //    {
    //        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    //    }
    //}
    //private void Moving()
    //{
    //    if (doing)
    //    {
    //        while (Mathf.Abs(par.transform.position.x - 0.04f)% 1.185f > 0.01f)
    //        {
    //            transform.parent.transform.MoveTowards(transform.parent.transform.position.x + 0.015f, transform.parent.transform.position.y);
    //        }
    //    }
    //    else
    //    {
    //        while (Mathf.Abs(par.transform.position.x - 0.04f) % 1.185f > 0.01f)
    //        {
    //            transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.015f, transform.parent.transform.position.y);
    //        }
    //    }
    //   // StartCoroutine(Doing());
    //}
    IEnumerator Doing()
    {
        yield return new WaitForSeconds(1.5f);
        //toDoing = false;
    }
    public void Move()
    {
        if (!left)
        {
            transform.parent.transform.position = new Vector2(transform.parent.transform.position.x + 0.01f, transform.parent.transform.position.y);
        }
    }
    private void Update()
    {
        if(par.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            isStat = true;
            left = true;
        }
        else
        {
            isStat = false;
        }
        float a = Mathf.Abs(transform.parent.transform.position.x - 0.04f);
        //Debug.Log(a);
        ////Debug.Log(5.2f%2.5f);
        //Debug.Log(a % 2f);
        //  Debug.Log(par.name);
        //if (!touch && !par.transform.Find("r").GetComponent<RTouch>().touch && !par.GetComponent<Stone>().isInAir)
        //{
        //    par.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //  //  isStat = false;
        //}
        
            //if (par.transform.Find("r").GetComponent<RTouch>().touch && !par.GetComponent<Stone>().isInAir && !isStat)
            //{
            //    par.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //    //   par.transform.position = new Vector2(par.transform.position.x - 0.001f, par.transform.position.y);

            //}
            //if (transform.parent.transform.position.x < -8.3f && !par.GetComponent<Stone>().isInAir)// && !par.transform.Find("r").GetComponent<RTouch>().toFloor)
            //{
            //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x + 0.01f, transform.parent.transform.position.y);
            //}
        if (a % 1.185f > 0.0075f && !left && a < 8.35f && !par.GetComponent<Stone>().isInAir && !isStat && par.transform.Find("d").transform.GetComponent<DTouch>().onStack)// && !par.GetComponent<Rigidbody2D>().isKinematic)// && !par.transform.Find("r").GetComponent<RTouch>().toFloor) //&& !transform.parent.transform.Find("r").GetComponent<RTouch>().touch)
        {
            transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);
            //Debug.Log("tanL");
        }

            else if (a % 1.185f > 0.0065f && !left && a < 8.35f && !par.GetComponent<Stone>().isInAir && !isStat)//&& !par.GetComponent<Rigidbody2D>().isKinematic)// && !par.transform.Find("r").GetComponent<RTouch>().toFloor) //&& !transform.parent.transform.Find("r").GetComponent<RTouch>().touch)
            {
                transform.parent.transform.position = new Vector2(transform.parent.transform.position.x + 0.01f, transform.parent.transform.position.y);
                //Debug.Log("tanL");
            }
            //else if (a % 1.185f > 0.01f && !left && !par.GetComponent<Stone>().isInAir && !isStat && par.transform.Find("r").GetComponent<RTouch>().toFloor)// && !transform.parent.transform.Find("l").GetComponent<LTouch>().touch)
            //{
            //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.001f, transform.parent.transform.position.y);
            //}
            //else if (a % 1.185f > 0.05f && !left && a < 8.35f && !par.GetComponent<Stone>().isInAir && isStat && !touch)// && !par.transform.Find("r").GetComponent<RTouch>().toFloor)
            //{
            //    par.transform.position = new Vector2(par.transform.position.x - 0.0001f, par.transform.position.y);
            //}
        
        //if (transform.parent.transform.Find("r").GetComponent<RTouch>().touch)
        //{
        //    float x = transform.parent.transform.position.x;
        //    transform.parent.transform.position = new Vector2(x, transform.parent.transform.position.y);
        //}
        //if (!ltomove && !left &&!par.GetComponent<Stone>().isInAir)
        //{
        //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);
        //}
        //else if (transform.parent.transform.Find("r").GetComponent<RTouch>().touch && a % 1.185f > 0.01f && a < 9.5f && !par.GetComponent<Stone>().isInAir)
        //{
        //    par.transform.GetComponent<Stone>().Freeze();
        //}
    }
}

