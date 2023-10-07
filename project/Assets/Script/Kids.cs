using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kids : MonoBehaviour
{
    private Vector3 m_setpos;   // プレイヤーからの距離
    static private int m_nSpawnCnt = 0; // 合計生成数
    private Kids m_Next;        // ネクスト
    private Kids m_prev;        // 手前

    public Kids Next
    {
        get { return m_Next; }
        set { m_Next = value; }
    }

    public Kids Prev
    {
        get { return m_prev; }
        set { m_prev = value; }
    }

    public Vector3 SetPos
    {
        get { return m_setpos; }
        set { m_setpos = value; }
    }

    static public int SpawnCnt
    {
        get { return m_nSpawnCnt; }
        set { m_nSpawnCnt = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 座標の移動
        Vector3 rot = transform.eulerAngles;
        
        transform.eulerAngles = rot;

        KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // プレイヤーを取得
        kidsManager.ListIn(this);
        SpawnCnt += 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 座標の移動
        Vector3 pos = transform.position;
        // プレイヤーから定位置までの更新
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // プレイヤーを取得

        if (player != null)
        {// 取得できた場合
            Vector3 vec = ((player.transform.position + m_setpos) - transform.position);
            pos.x += vec.x * 0.0075f;
            pos.y += vec.y * 0.0075f;
        }

        transform.position = pos;
    }

    public void Set(Vector3 pos, Vector3 setpos)
    {
        transform.position = pos;
        m_setpos = setpos;
    }

    private void OnTriggerEnter(Collider colider)
    {
        // 敵かどうか確認
        if (colider.gameObject.CompareTag("Enemy"))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // プレイヤーを取得
            kidsManager.ListOut(this);
            Destroy(gameObject);
        }
    }
}
