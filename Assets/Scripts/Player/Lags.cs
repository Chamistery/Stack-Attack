using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lags : MonoBehaviour
{
    public static bool toJump = true;
    public bool toSee;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Floor" || collision.tag == "StackBack")
        {
            toJump = true;
          //  Debug.Log(0);
        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor" || collision.tag == "StackBack")
        {
            toJump = false;
          //  Debug.Log(1);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Floor" || collision.tag == "StackBack")
    //    {
    //        toJump = true;
    //        Debug.Log(2);
    //    }
    //}
    private void Update()
    {
        toSee = toJump;
    }
}
