using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantStack : MonoBehaviour
{
  //  private const float V = 9.16f;
    public AnimationCurve movementCurve;
    public GameObject claw;
    public GameObject _iron;
    public GameObject _stone;
    public GameObject taker;
    public static int count = 0;
    public static bool isSpawn;
  //  float x = 0;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // x = x + 0.1f;
        int a = Random.Range(1,5);
        int b = Random.Range(1, 3);

        if (count < 5 && !isSpawn)
        {
            int j = a;
            GameObject _item;
            float posX = 0;
            if (b == 1)
                posX = 9.16f;
            else
                posX = -8.5f;
            if (j == 1)
                _item = _stone;
            else
                _item = _iron;
            var Claw = Instantiate(claw, new Vector3(posX, 2.6f,0), Quaternion.identity);
            var item = Instantiate<GameObject>(_item, new Vector3(Claw.transform.position.x-0.23f, 2.75f, 0), Quaternion.identity, Claw.transform);
            var _taker = Instantiate(taker, new Vector3(item.transform.position.x, item.transform.position.y - 1.1f, 0), Quaternion.identity, Claw.transform);
            //if (j == 1)
            //    Claw.transform.GetComponent<Transfer>().item = true;
            //else
            //    Claw.transform.GetComponent<Transfer>().item = false;
            count++;
            StartCoroutine(spawning());
        }
    }
    private IEnumerator spawning()
    {
        isSpawn = true;
        float x = Random.Range(2, 6);
        yield return new WaitForSeconds(x);
        isSpawn = false;
        x = 0;
    }
}
