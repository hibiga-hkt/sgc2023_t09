using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private Vector3 m_move; // 移動量
    private int m_MoveCnt;  // 移動カウント
    [SerializeField]
    private GameObject m_SpawnKidsPrefab;    // 生成する子供プレハブ

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(m_MoveCnt < 0)
        {
            // プレイヤーから定位置までの更新
            GameManager gamemanager = GameManager.Instance; // マネージャーを取得

            // 子供生成
            GameObject obj = Instantiate(m_SpawnKidsPrefab, transform.position, Quaternion.identity);

            Kids kids = obj.GetComponent<Kids>();
            kids.Idx = gamemanager.SpawnCnt;
            gamemanager.SpawnCnt = gamemanager.SpawnCnt + 1;
            kids.Set(transform.position, new Vector3(-2.0f - kids.Idx / (gamemanager.HeightCnt)
                , -((gamemanager.HeightCnt - 1) * 0.5f) + (kids.Idx % (gamemanager.HeightCnt)), 0.0f));

            // 自身を消す
            Destroy(gameObject);
        }
        else
        {
            Vector3 pos = transform.position;
            pos += m_move * Time.deltaTime;
            m_move *= 0.99f;
            m_MoveCnt--;

            transform.position = pos;
        }
    }

    public void Set(Vector3 pos, Vector3 move)
    {
        transform.position = pos;
        m_move = move;
        m_MoveCnt = 240;
    }
}
