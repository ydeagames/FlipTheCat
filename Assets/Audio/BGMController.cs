using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource audioSource;
    public int step = 0;
    public List<ClipDefine> clips;
    bool deadding;
    public float pitchDownSpeed = 0.01f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (step < clips.Count)
        {
            var clip = clips[step];
            // 再生中のBGMの再生時間を監視する
            if (clip != null && audioSource != null)
            {
                if (!audioSource.isPlaying || clip.endTime > 0 && audioSource.time >= clip.endTime)
                {
                    Debug.Log("loop: " + step + ", now: " + audioSource.time + ", end: " + clip.endTime);
                    if (clip.through)
                        step++;
                    else
                        audioSource.time = clip.startTime;
                }
            }
        }
        if (deadding)
        {
            audioSource.pitch = Mathf.Max(0, audioSource.pitch - pitchDownSpeed);
        }
    }

    public void StartMain()
    {
        step = 2;
    }

    public void Dead()
    {
        deadding = true;
    }

    [System.Serializable]
    public class ClipDefine
    {
        /// <summary>
        /// 区間のスタート時間
        /// </summary>
        public float startTime;
        /// <summary>
        /// 区間の終了時間
        /// </summary>
        public float endTime;

        public bool through;

        public ClipDefine(float startTime = 0, float endTime = -1, bool through = false)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.through = through;
        }
    }
}
