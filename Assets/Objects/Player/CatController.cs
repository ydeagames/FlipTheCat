using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CatController : MonoBehaviour
{
    public float cooldownTime = 0.3f;
    public float frictionRotate = 0.9f;
    public float gravity = 0.1f;
    public float frictionX = 0.96f;
    public float rotateSpeed = 15;
    public float jumpPower = 5;
    public float maxHorizontalSpeed = 0.5f;
    public float maxUpSpeed = 2.4f;
    public float maxDownSpeed = 0.6f;
    public float maxRotationSpeed = 0.5f;
    public float minRotationSpeed = 0.2f;

    public AudioClip jumpSe;
    public AudioClip nojumpSe;

    GameDirector director;
    Vector3 velocity;
    float rotate = 1;
    float rotateDirection = 1;
    float time;
    bool paused = true;

    float highest;
    bool deadFlag;
    public float deadZone = 20;

    BGMController bgm;

    float highscore;

    public float GetCameraPosition()
    {
        return Mathf.Max(transform.position.y, highest - deadZone);
    }

    // Use this for initialization
    void Start()
    {
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        bgm = GameObject.Find("BGM").GetComponent<BGMController>();
        highscore = PlayerPrefs.GetFloat("flipthecat.highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!deadFlag && time > cooldownTime && Input.GetButtonDown("Submit"))
        {
            if (paused)
                bgm.StartMain();
            paused = false;
            time = 0;
            if (director.hp > 0)
            {
                velocity = (transform.up * jumpPower);
                rotate = 1;
                director.hp--;
                if (0 <= transform.eulerAngles.z && transform.eulerAngles.z < 180)
                {
                    rotateDirection = 1;
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    rotateDirection = -1;
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                GetComponent<Animator>().SetTrigger("JumpTrigger");
                GetComponent<AudioSource>().PlayOneShot(jumpSe);
            }
            else
            {
                Camera.main.GetComponent<CameraShake>().Shake(0.15f, 0.5f);
                GetComponent<AudioSource>().PlayOneShot(nojumpSe);
            }
        }
        velocity.x = Mathf.Clamp(velocity.x * frictionX, -maxHorizontalSpeed, maxHorizontalSpeed);
        velocity.y = Mathf.Clamp(velocity.y - gravity * 60 * Time.deltaTime, -maxDownSpeed, maxUpSpeed);
        rotate = Mathf.Clamp(rotate * frictionRotate, minRotationSpeed, maxRotationSpeed);

        if (!paused)
        {
            transform.Rotate(Vector3.forward, rotate * rotateDirection * rotateSpeed * 60 * Time.deltaTime);
            transform.position += velocity * 60 * Time.deltaTime;
        }
        time += Time.deltaTime;

        float left = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        Vector3 workpos = transform.position;
        workpos.x = Mathf.Repeat(workpos.x - left, right - left) + left;
        transform.position = workpos;

        highest = Mathf.Max(highest, transform.position.y);
        float high = Mathf.Max(highest, highscore);
        if (!deadFlag && highest - transform.position.y > deadZone)
        {
            deadFlag = true;
            bgm.Dead();
            GameObject.Find("Black").GetComponent<BlackController>().fadeOut();
            director.OnDead();
            if (highest > highscore)
            {
                PlayerPrefs.SetFloat("flipthecat.highscore", high);
                PlayerPrefs.SetString("flipthecat.date", DateTime.Now.ToString());
            }
            GameObject.Find("Score").GetComponent<Text>().text = "Score " + highest.ToString("F2") + "m"
                + "\n" + "Highscore " + high.ToString("F2") + "m";
        }
        bool mark = highest > highscore && ((int)Time.time % 2) == 0;
        GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore " + high.ToString("F2") + "m" + (mark ? " !!" : " ");
    }
}
