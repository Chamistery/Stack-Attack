using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;
    public GameObject player;
    public static bool Side;
    Rigidbody2D rb;
   // public int num = 0;
    Animator anim;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
    private void FixedUpdate()
    {
        if((buttonPressed || Input.GetAxis("Horizontal") < -.1f) && UpButton.buttonPressed)
        {
            if (Side)
            {
                player.transform.Rotate(0, -180, 0);
                Right();
            }
            anim.ResetTrigger("IdleL");
            anim.ResetTrigger("LeftWalk");
           // player.transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.AddForce(Vector2.left * 500);
        }
        else  if (buttonPressed || Input.GetAxis("Horizontal") < -.1f)
        {
            if (Side)
            {
                player.transform.Rotate(0, -180, 0);
                Right();
            }
            //  anim.ResetTrigger("IdleR");
            anim.SetTrigger("IdleL");
         //   player.transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.AddForce(Vector2.left * 500);
            anim.SetTrigger("LeftWalk");
        }
        else//if(UpButton.buttonPressed)
        {
            anim.ResetTrigger("LeftWalk");
            anim.SetTrigger("IdleL");
        }
    }
    public void Right()
    {
        Side = false;
    }
}

