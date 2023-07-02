using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class UpButton : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{
    public static bool buttonPressed;
    public GameObject player;
   // public GameObject shadow;
    Rigidbody2D rb;
    Vector2 pos;
    //public int num = 0;
    Animator anim;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
      // pos = shadow.transform.position;
        //  Button button = GetComponent<Button>();
    }
    // Start is called before the first frame update
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    buttonPressed = true;
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    buttonPressed = false;
    //}
    public void Jump()
    {
        if (!buttonPressed && Lags.toJump)
        {
          // shadow.transform.position = new Vector2(shadow.transform.position.x, -2.3f);
            anim.ResetTrigger("RightWalk");
            anim.ResetTrigger("LeftWalk");
            anim.SetTrigger("RightJump");
            anim.SetTrigger("IdleL");
            buttonPressed = true;
            //  rb.velocity = Vector2.up * Time.deltaTime * 350;
            rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
            StartCoroutine(waiting());
        }
    }
    private IEnumerator waiting()
    {
        yield return new WaitForSeconds(1);
        buttonPressed = false;
       // shadow.transform.position = pos;
    }
}
