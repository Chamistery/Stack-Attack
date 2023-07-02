using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StackBack" && Mathf.Abs(transform.parent.transform.position.x - 0.04f) % 1.185f < 0.01f && !transform.parent.GetComponent<Stone>().isInAir)
        {
            transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        //else if (collision.tag == "StackBack" && !transform.parent.GetComponent<Stone>().isInAir)
        //{
        //    if(Mathf.Abs(transform.parent.transform.position.x - 0.04f) % 1.185f < 0.01f)
        //    {
        //        collision.transform.Find("l").GetComponent<LTouch>().Move();
        //        transform.parent.transform.Find("l").GetComponent<LTouch>().Move();
        //        collision.transform.Find("r").GetComponent<RTouch>().Move();
        //        transform.parent.transform.Find("r").GetComponent<RTouch>().Move();
        //    }
        //}
    }
}
