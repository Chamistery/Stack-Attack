using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool inChain = true;
    public bool isInAir = true;
    private bool smth;
    public bool toDoing;
    private bool doing;
    public bool toDown = true;
    public GameObject d;
    Rigidbody2D rb;
   // private bool isStacking;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Stack")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            rb.isKinematic = true;
        }
        //if(isStacking)
        //{
        //    Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        //    StartCoroutine(ignoring());
        //}
    }
    public void destroy()
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        d.SetActive(false);
        rb = this.GetComponent<Rigidbody2D>();
    }
    //public void Freeze()
    //{
    //    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    //}
    // Update is called once per frame
    //IEnumerator ignoring()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    isStacking = false;

    //}
    public void Moving(bool fromWhere)
    {
        if (!toDown)
        {
            Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -2.0657f), Time.deltaTime * 1);
            if(transform.position.y == -2.0657f)
                toDown = true;
        }
        if (fromWhere) {
            if (doing)
            {
                if (Mathf.Abs(transform.position.x - 0.04f) % 1.185 > 0.01)
                {
                    transform.position = new Vector2(transform.position.x - .01f, transform.position.y);
                    StartCoroutine(Doing());
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.x - 0.04f) % 1.185 > 0.01)
                {
                    transform.position = new Vector2(transform.position.x + .01f, transform.position.y);
                    StartCoroutine(Doing());
                }
            }
        }
    }
    IEnumerator Doing()
    {
        yield return null;
        Moving(true);
    }
    void Update()
    {
        if (transform.position.x > 8.33f && !isInAir && !inChain && !transform.Find("l").GetComponent<LTouch>().touch)// && !par.transform.Find("l").GetComponent<LTouch>().toFloor)
        {
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
        }
        if (transform.position.x < -8.3f && !isInAir && !inChain && !transform.Find("r").GetComponent<RTouch>().touch)// && !par.transform.Find("l").GetComponent<LTouch>().toFloor)
        {
            transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
          //  Debug.Log("Why doesnt work!?");
        }
        if (inChain)
        {

            transform.position = new Vector3(transform.parent.transform.position.x - 0.23f, 2.75f, 0);
        }
        if (isInAir && Mathf.Abs(transform.position.x-0.04f) % 1.185f > 0.01f && !toDoing && !inChain && Mathf.Abs(transform.position.x) < 8.25f && !transform.Find("l").GetComponent<LTouch>().left && !transform.Find("r").GetComponent<RTouch>().right)
        { 
            if (Mathf.Abs(transform.position.x - 0.04f) % 1.185 - 0.5925f > 0.5f && !transform.Find("r").GetComponent<RTouch>().touch)
            {
                doing = true;
                Moving(true);
            }
            else if (!transform.Find("l").GetComponent<LTouch>().touch)
            {
                doing = false;
                Moving(true);
            }
            toDoing = true;
            Debug.Log("InAir");
        }
        else if (isInAir && Mathf.Abs(transform.position.x - 0.04f) % 1.185f > 0.01f && !toDoing && !inChain && Mathf.Abs(transform.position.x) < 8.25f)
        {
            if (transform.Find("r").GetComponent<RTouch>().right && !transform.Find("l").GetComponent<LTouch>().touch)
            {
                doing = true;
                Moving(true);
            }
            if(transform.Find("l").GetComponent<LTouch>().left && !transform.Find("r").GetComponent<RTouch>().touch)
            {
                doing = false;
                Moving(true);
            }
            toDoing = true;
        }
        //var dis = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(0, -1), 10).distance;
        //var floor = Physics2D.Raycast(new Vector2(transform.position.x, this.transform.position.y), new Vector2(0, -1), 10).collider;
        if (transform.parent == null && isInAir && !smth)
        {
            d.SetActive(true);
            rb.isKinematic = false;
            change();
            smth = true;
            //StartCoroutine(air());
        }
    }
    public void change()
    {
        this.transform.tag = "StackBack";
      //  isStacking = true;
    }
    //public IEnumerator air()
    //{
    //    yield return new WaitForSeconds(3f);
    //    isInAir = false;
    //}
} 
