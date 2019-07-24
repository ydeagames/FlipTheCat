using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareButton : MonoBehaviour
{
    // Use this for initialization
    public void Clicked()
    {
        var name = GameObject.Find("ShareInputText").GetComponent<Text>().text;
        if (name != null && name != "")
        {
            var score = PlayerPrefs.GetFloat("flipthecat.highscore", 0);
            if (score > 0 && PlayerPrefs.HasKey("flipthecat.date"))
            {
                var date = PlayerPrefs.GetString("flipthecat.date");
                var serialText = name.Replace("&", "") + "&" + score.ToString("F2") + "&" + date;
                var encText = Decryption.Encrypt(serialText, Decryption.iv, Decryption.key);
                var url = "https://ydeagames.github.io/FlipTheCat/#/" + encText;
                //Application.OpenURL(url);
                Application.OpenURL("https://twitter.com/intent/tweet?text=" +name+" が FlipTheCat で "+score.ToString("F2")+"m のジャンプをしました！\n結果を見る↓\n&url="+WWW.EscapeURL(url)+"&hashtags=FlipTheCat");
                GameObject.Find("ShareInputField").GetComponent<InputField>().interactable = false;
            }
        }
    }
}
