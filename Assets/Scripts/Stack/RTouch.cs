using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTouch : MonoBehaviour
{
    public bool right;
    public GameObject par;
    public bool touch;
    public bool isStat;
    public bool onStack;
  //  public bool toFloor;
    //private bool rtomove;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !par.GetComponent<Stone>().isInAir && !isStat)
        {
            transform.parent.transform.Find("l").GetComponent<LTouch>().left = true;
            right = true;
            Debug.Log(0);
        }
        else if(collision.tag == "Player" && par.GetComponent<Stone>().isInAir && !isStat)
        {
            right = true;
        }
        //else if(collision.tag == "Player" && !par.GetComponent<Stone>().isInAir && isStat)
        //{
        //    right = true;
        ////    if()
        //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);

        //}
        if(collision.tag == "StackBack")// && !collision.GetComponent<Stone>().isInAir)
        {
            touch = true;
        }
        if(collision.tag == "Floor" && !par.GetComponent<Stone>().isInAir)
        {
            if(!isStat)
                transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);
            par.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            isStat = true;
          //  toFloor = true;
        }
        //if (collision.tag == "Respawn")
        //{
        //    rtomove = true;
        // //   Debug.Log(000);
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            right = false;
            Debug.Log(1);
        }
        //if (collision.tag == "StackBack")
        //{
        //    touch = false;
        //}
        //if(collision.tag == "Respawn")
        //{
        //    rtomove = false;
        //}
    }
    public void Move()
    {
        if (!right)
        {
            transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);
        }
    }
    private void Update()
    {
        if (par.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            isStat = true;
            right = true;
        }
        else
        {
            isStat = false;
        }
        float a = Mathf.Abs(transform.parent.transform.position.x - 0.04f);
        //  Debug.Log(a);
        //Debug.Log(5.2f%2.5f);
        //  Debug.Log(a % 2f);

        //if (!touch && !par.transform.Find("l").GetComponent<LTouch>().touch && !par.GetComponent<Stone>().isInAir)
        //{
        //    par.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //    // isStat = false;
        //}
        //if (par.GetComponent<Stone>().isInAir && right && a % 1.185f > 0.01f && !transform.parent.transform.Find("l").GetComponent<LTouch>().touch)
        //{
        //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.015f, transform.parent.transform.position.y);
        //}
        //else
        //{
        if ((par.transform.Find("l").GetComponent<LTouch>().touch || touch)&& !par.GetComponent<Stone>().isInAir && !isStat)//a && !par.GetComponent<Rigidbody2D>().isKinematic)
        {
            par.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Debug.Log(8);
                //par.transform.position = new Vector2(par.transform.position.x + 0.01f, par.transform.position.y);
            isStat = true;
        }

        if (a % 1.185f > 0.0075f && !right && a < 8.33f && !par.GetComponent<Stone>().isInAir && !isStat && par.transform.Find("d").transform.GetComponent<DTouch>().onStack )//÷¸&& !par.GetComponent<Rigidbody2D>().isKinematic)
        {
            transform.parent.transform.position = new Vector2(transform.parent.transform.position.x + 0.01f, transform.parent.transform.position.y);
        }
        else if (a % 1.185f > 0.0065f && !right && a < 8.33f && !par.GetComponent<Stone>().isInAir && !isStat) //&& !par.GetComponent<Rigidbody2D>().isKinematic)// && !par.transform.Find("l").GetComponent<LTouch>().toFloor)// && !transform.parent.transform.Find("l").GetComponent<LTouch>().touch)
        {
            transform.parent.transform.position = new Vector2(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y);
              //  Debug.Log("tanR");
        }
        //    else if (a % 1.185f > 0.01f && !right && a < 8.33f && !par.GetComponent<Stone>().isInAir && !isStat && onStack)
        //{

        //}
            //else if (a % 1.185f > 0.01f && !right && !par.GetComponent<Stone>().isInAir && !isStat && par.transform.Find("l").GetComponent<LTouch>().toFloor)// && !transform.parent.transform.Find("l").GetComponent<LTouch>().touch)
            //{
            //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x + 0.001f, transform.parent.transform.position.y);
            //}
            //else if (a % 1.185f > 0.05f && !right && a < 8.33f && !par.GetComponent<Stone>().isInAir && isStat && !touch)// && !par.transform.Find("l").GetComponent<LTouch>().toFloor)
            //{
            //    par.transform.position = new Vector2(par.transform.position.x + 0.0001f, par.transform.position.y);
            //}
            //  }
            //else if(a % 1.185f > 0.05f && !right && a < 8.33f && !par.GetComponent<Stone>().isInAir && isStat && touch)
            //{

            //}
            //if (transform.parent.transform.Find("l").GetComponent<LTouch>().touch)
            //{
            //    float x = transform.parent.transform.position.x;
            //    transform.parent.transform.position = new Vector2(x, transform.parent.transform.position.y);
            //}
            //if (!rtomove && !right && !par.GetComponent<Stone>().isInAir)
            //{
            //    transform.parent.transform.position = new Vector2(transform.parent.transform.position.x + 0.01f, transform.parent.transform.position.y);
            //}
            //else if(transform.parent.transform.Find("l").GetComponent<LTouch>().touch && a % 1.185f > 0.01f && a < 9.5f && !par.GetComponent<Stone>().isInAir)
            //{
            //    par.transform.GetComponent<Stone>().Freeze();
            //}
    }
}
