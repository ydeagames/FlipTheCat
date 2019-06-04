using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public int maxHp;
    int nowHp;
    public GameObject hpGauge;

    public int hp
    {
        get
        {
            return nowHp;
        }

        set
        {
            nowHp = Mathf.Clamp(value, 0, maxHp);
            hpGauge.GetComponent<Image>().fillAmount = (float)nowHp / maxHp;
        }
    }

    // Use this for initialization
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDead()
    {

    }
}
