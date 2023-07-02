using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;
    public GameObject player;
    Rigidbody2D rb;
 //   public int num = 0;
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
        if ((buttonPressed || Input.GetAxis("Horizontal") > .1f) && UpButton.buttonPressed)
        {
            if (!LeftButton.Side)
            {
                player.transform.Rotate(0, 180, 0);
                Left();
            }
            anim.ResetTrigger("IdleL");
            anim.ResetTrigger("RightWalk");
            player.transform.rotation = new Quaternion(0, -180, 0, 0);
            rb.AddForce(Vector2.right * 300);
        }
        else if (buttonPressed || Input.GetAxis("Horizontal") > .1f)
        {
            if (!LeftButton.Side)
            {
                player.transform.Rotate(0, 180, 0);
                Left();
            }
            
            //  anim.ResetTrigger("IdleR");
            anim.ResetTrigger("IdleL");
            player.transform.rotation = new Quaternion(0, -180, 0, 0);
            rb.AddForce(Vector2.right * 300);
            anim.SetTrigger("RightWalk");
        }
        else //if(!UpButton.buttonPressed)
        {
            anim.ResetTrigger("RightWalk");
            anim.SetTrigger("IdleL");
        }
    }
    public void Left()
    {
        LeftButton.Side = true;
    }
}
