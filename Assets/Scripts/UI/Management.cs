using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static int points = 0;
    public static bool toShow;
    public static int healths;
    public GameObject hp;
    public GameObject canv;
    public int countHealths;
    public static Dictionary<int, GameObject> hpDic = new Dictionary<int, GameObject>();

    private void Awake()
    {
        points = 0;
        healths = countHealths;
        for (int i = 1; i <= countHealths; i++)
        {
            var curHp = Instantiate(hp, new Vector2(575 + i*250, 120), Quaternion.identity, canv.transform);
            hpDic.Add(i, curHp);
        }
    }
    public static void Delete()
    {
        Destroy(hpDic[healths]);
        hpDic.Remove(healths);
        healths--;
    }
}
