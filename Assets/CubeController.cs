using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeController : MonoBehaviour
{
    //unityちゃん取得
    private GameObject unitychan2D;

    //AudioSource取得
    AudioSource audioSource;

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start()
    {
        //Components取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ブロック同士が当たった時、あるいは地面に当たったときに音をならす
        if (collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "GroundTag")
        {
            GetComponent<AudioSource>().Play();
        }
        //ユニティちゃんが出現したときに音を消す
            if (collision.gameObject.tag == "UnityChanTag")
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }

}
