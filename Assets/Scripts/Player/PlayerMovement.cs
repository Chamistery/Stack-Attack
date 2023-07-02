using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
   // public Button right;
    //public Button left;
    //public Button up;
    //private bool isClicked;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    rb.velocity = Vector2.right * 100;
    //}
}
