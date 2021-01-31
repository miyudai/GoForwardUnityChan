﻿using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    // スクロール速度
    private float scrollSpeed = -1;
    // 背景終了位置
    private float deadLine = -16;
    // 背景開始位置
    private float startLine = 15.8f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 背景を移動する
        transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);

        // 画面外に出たら、画面右端に移動する
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }

    //キューブ同士が当たったら音を鳴らす
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CubeTag")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}