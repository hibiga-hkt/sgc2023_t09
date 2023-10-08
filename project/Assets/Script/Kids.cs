using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kids : MonoBehaviour
{
    private Vector3 m_setpos;   // プレイヤーからの距離
    private Kids m_Next;        // ネクスト
    private Kids m_prev;        // 手前
    private int m_Idx;           // 番号
    private Vector3 m_move;   // 移動量
    [SerializeField]
    private int nAddCount;  // 加算ポイント数
    [SerializeField]
    public GameObject particlePrefab; // パーティクルシステムのプレハブをInspectorから設定
    [SerializeField]
    AudioClip clip;
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

    public int Idx
    {
        get { return m_Idx; }
        set { m_Idx = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_move.x = 0;
        m_move.y = 0;
        m_move.z = 0;
        // 座標の移動
        Vector3 rot = transform.eulerAngles;
        
        transform.eulerAngles = rot;

        KidsManager kidsManager = KidsManager.Instance; // プレイヤーを取得
        kidsManager.ListIn(this);

        ScoreManager scoremanager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>(); // マネージャーを取得
        scoremanager.AddScore(nAddCount);
    }

    // Update is called once per frame
    void Update()
    {
        Kids kids = m_prev;
        int nCount;
        for (nCount = 0; nCount < GameManager.Instance.HeightCnt; nCount++)
        {
            if (kids != null)
            {
                kids = kids.m_prev;
            }
            else
            {
                break;
            }
        }
      
        // 座標の移動
        Vector3 pos = transform.position;
        // プレイヤーから定位置までの更新
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // プレイヤーを取得

        if (player != null)
        {// 取得できた場合
            if(nCount == GameManager.Instance.HeightCnt)
            {
                if (kids != null)
                {
                    Vector3 vec = kids.transform.position - transform.position;
                    Vector3 dis = vec;
                    float fDis = 0.0f;
                    if (dis.x < 0)
                    {
                        dis.x *= -1;
                    }
                    if (dis.y < 0)
                    {
                        dis.y *= -1;
                    }
                    fDis += dis.x;
                    fDis += dis.y;
                    if (fDis >= 2.5f)
                    {
                        pos.x += vec.x * 0.065f;
                        pos.y += vec.y * 0.065f;
                    }
                }
                else
                {
                    Vector3 vec = ((player.transform.position ) - transform.position);
                    Vector3 dis = vec;
                    float fDis = 0.0f;
                    if (dis.x < 0)
                    {
                        dis.x *= -1;
                    }
                    if (dis.y < 0)
                    {
                        dis.y *= -1;
                    }
                    fDis += dis.x;
                    fDis += dis.y;
                    if (fDis >= 2.5f)
                    {
                        m_move.x += vec.x * 0.0003f;
                        m_move.y += vec.y * 0.0003f;
                    }
                }
            }
            else
            {
                m_setpos.x = 0.0f;
                Vector3 vec = ((player.transform.position +m_setpos) - transform.position);
                Vector3 dis = vec;
                float fDis = 0.0f;
                if (dis.x < 0)
                {
                    dis.x *= -1;
                }
                if (dis.y < 0)
                {
                    dis.y *= -1;
                }
                fDis += dis.x;
                fDis += dis.y;
                if (fDis >= 2.5f)
                {
                    m_move.x += vec.x * 0.0003f;
                    m_move.y += vec.y * 0.0003f;
                }
            }
           
        }
        pos += m_move;
        transform.position = pos;
        m_move *= 0.98f;
    }

    public void Set(Vector3 pos, Vector3 setpos)
    {
        transform.position = pos;
        m_setpos = setpos;
    }

    private void OnTriggerEnter(Collider colider)
    {
        // 敵かどうか確認
        if (colider.gameObject.CompareTag("Enemy") || colider.gameObject.CompareTag("Obstacle"))
        {
            SoundManager.Instance.PlaySound(clip);
            // プレハブをインスタンス化
            GameObject particleSystemInstance = Instantiate(particlePrefab);

            // パーティクルシステムをアクティブにする
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();
            particleSystemInstance.transform.position = transform.position;
            particleSystem.Play();

            KidsManager kidsManager = KidsManager.Instance; // プレイヤーを取得
            kidsManager.ListOut(this);

            ScoreManager scoremanager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>(); // マネージャーを取得
            scoremanager.AddScore(-nAddCount);
            Destroy(gameObject);
        }
    }
}
