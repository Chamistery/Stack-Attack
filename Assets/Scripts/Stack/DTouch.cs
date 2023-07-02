using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTouch : MonoBehaviour
{
    public GameObject text;
    public bool onStack;
   // public GameObject canv;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "StackBack"&& !transform.parent.Find("l").GetComponent<LTouch>().touch && !transform.parent.Find("r").GetComponent<RTouch>().touch)//&& transform.parent.tag != "Stack")
        {
            transform.parent.transform.GetComponent<Stone>().isInAir = false;
            //transform.parent.transform.GetComponent<Stone>().toDoing = false;
            //transform.parent.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            onStack = false;
            Debug.Log(88);
            // Debug.Log(100);
        }
        if (collision.tag == "Floor")
        {
           // onStack = false;
            transform.parent.transform.GetComponent<Stone>().isInAir = false;
            transform.parent.transform.GetComponent<Stone>().toDown = false;
            transform.parent.transform.GetComponent<Stone>().Moving(false);
            //transform.parentransform.parent.transform.GetComponent<Stone>().t.transform.position = new Vector3(transform.parent.transform.position.x, -2.0657f);
        }
        //if (collision.tag == "Floor" && transform.parent.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        //{
        //    // onStack = false;
            
        //    //transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, -2.0657f);
        //}
        if (collision.tag == "Head")
        {
            if(transform.parent.name == "Iron(Clone)")
            {
                Management.Delete();
            }
            else if(transform.parent.name == "Stone(Clone)")
            {
                Management.points += 50;
                var point = Instantiate(text, Vector3.zero, Quaternion.identity);//, GameObject.Find("Canvas").transform);
                point.GetComponent<Text>().text = "50";
                point.transform.SetParent(GameObject.Find("Canvas").transform);
                point.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0));
            }
            transform.parent.transform.GetComponent<Stone>().destroy();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "StackBack")//&& transform.parent.tag != "Stack")
        {
            transform.parent.transform.GetComponent<Stone>().isInAir = true;
            onStack = true;
            //  transform.parent.transform.GetComponent<Stone>().toDoing = false;
            // Debug.Log(100);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
