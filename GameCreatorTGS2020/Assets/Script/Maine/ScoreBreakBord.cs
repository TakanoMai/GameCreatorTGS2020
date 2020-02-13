﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBreakBord : MonoBehaviour
{
    private GameObject[] audioobjects;
    private GameObject[] audioobjects2;
    private GameObject[] Bords;

    private int Number;
    private float Score;

    private Animator[] animator;

    private float time;
    private int loop;

    bool Score_Check=false;
    float Score_MAX = 0;
    float Score_MIN = 0;
    float Score_NUM = 0;
    float Score_difference = 0;

    int anim_save=0;

    int anim_Num=0;

    int test = 0;

    int num = 0;

    public float speed;

    public bool[]  break_anim;


    // Start is called before the first frame update
    void Start()
    {
        audioobjects = GameObject.FindGameObjectsWithTag("audio");
        audioobjects2 = GameObject.FindGameObjectsWithTag("audioend");
        Number = this.GetComponent<InstantiateBord>().GetNumber();
        Bords = this.GetComponent<InstantiateBord>().GetBords();
        animator = new Animator[Number];
        //Debug.Log(Bords[0]);

        for(int lp = 0;lp < Number; lp++)
        {
            Bords[lp] = this.GetComponent<InstantiateBord>().GetBords()[lp];
            animator[lp] = Bords[lp].GetComponent<Animator>();
            break_anim[lp] = Bords[lp].GetComponent<Break_Anime>().Break_borad;
        }

        /////////////////////////////////////本来Updateのほうが適しているがprtでは処理のためこちらに記入

        time = 5;
        loop = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_Num + anim_save - 1 >= 0)
        {
            Bords[(anim_Num + anim_save - 1)].GetComponent<Break_Anime>().Break_borad = true;
        }
        time += Time.deltaTime;

        if (Score_Check == true)
        {
            if (anim_Num < Score)
            {
                anim_Num = Mathf.FloorToInt(time*speed);
            }
        }

        if (Score_NUM == 0)//最初のスコア取得
        {
            Score_MIN = GetScore.Score;//スコアの初期値取得
            Score_NUM = GetScore.Score;
        }
        else
        {
            Score_NUM = GetScore.Score;
        }

        Score = Score_NUM - Score_MIN;

        if (Score_MAX < Score)
        {
            Score_difference = Score - Score_MAX;
            Score_MAX = Score;
            Score_Check = true;
            anim_save = anim_Num;
        }
        if (loop <= Score - 1)
            {
                //var audioobject = audioobjects[Random.Range(1, 5)];
                //audioobject.GetComponent<AudioSource>().Play();
                loop = loop + 1;
                time = 0;
                //Debug.Log(Bords[loop]);
            }else{
                //var audioobject2 = audioobjects2[0];
                //audioobject2.GetComponent<AudioSource>().Play();
            }
    }
}

