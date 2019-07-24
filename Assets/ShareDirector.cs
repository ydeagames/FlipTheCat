using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShareDirector : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        try
        {
            var url = Application.absoluteURL;
            //var url = "https://ydeagames.github.io/FlipTheCat/#/B4B8tTIWa7TA78FqI/pqaURdkte3765S4R7vB7//YF5SsLpvNb46Ix02NT0WcP4H";
            var foundS1 = url.IndexOf("/#/");
            var enc = url.Substring(foundS1 + 3, url.Length - 3 - foundS1);
            var dec = Decryption.Decrypt(enc, Decryption.iv, Decryption.key);
            var data = dec.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
            var name = data[0];
            var score = data[1];
            var date = data[2];

            GameObject.Find("ResultText").GetComponent<Text>().text = name + "\n ハイスコア " + score + "m" + "\n ( " + date + " )";
            return;
        }
        catch (Exception)
        {
        }
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            OnStart();
    }

    public void OnStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
