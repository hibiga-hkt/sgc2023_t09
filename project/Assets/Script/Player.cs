using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 m_move; // 移動量

    [SerializeField]
    private float m_Speed;  // 移動速度
    [SerializeField]
    private float m_fMulti; // 慣性

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 当たり判定
        Vector3 pos = transform.position;   // 移動後の座標を取得

        // 画面の判定座標を取得
        Vector3 leftDown = Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width, -Screen.height)); // 左下の座標
        Vector3 rightUp = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // 右上の座標

        // スプライトの幅高さ取得

        // 移動
        if (Input.GetKey(KeyCode.A))
        {// Aキーが押されたとき
            if (Input.GetKey(KeyCode.W))
            {// Wキーが押されたとき
                m_move.x += Mathf.Sin(-Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(-Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {// Sキーが押されたとき
                m_move.x += Mathf.Sin(-Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(-Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
            }
            else
            {// 同時押しされていない
                m_move.x += Mathf.Sin(-Mathf.PI * 0.5f) * m_Speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {// Dキーが押されたとき
            if (Input.GetKey(KeyCode.W))
            {// Wキーが押されたとき
                m_move.x += Mathf.Sin(Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {// Sキーが押されたとき
                m_move.x += Mathf.Sin(Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
            }
            else
            {// 同時押しされていない
                m_move.x += Mathf.Sin(Mathf.PI * 0.5f) * m_Speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {// Wキーが押されたとき
            m_move.y += Mathf.Cos(Mathf.PI * 0.0f) * m_Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {// Sキーが押されたとき
            m_move.y += Mathf.Cos(Mathf.PI * 1.0f) * m_Speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // プレイヤーを取得
            kidsManager.SetAvoid();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // プレイヤーを取得
            kidsManager.SetFormation();
        }

        pos += m_move;   // 移動量を加算

        // 当たり判定
        //pos.x = Mathf.Clamp(pos.x, leftDown.x, rightUp.x);
        //pos.y = Mathf.Clamp(pos.y, leftDown.y, rightUp.y);

        // 移動量減衰
        m_move.x += (0.0f - m_move.x) * m_fMulti;   //x座標
        m_move.y += (0.0f - m_move.y) * m_fMulti;	//y座標

        // 座標更新
        transform.position = pos;

        transform.Translate(m_move.x, m_move.y, m_move.z, Space.World); // 移動量を加算
    }

    private void OnTriggerEnter(Collider colider)
    {
        // 敵かどうか確認
        if (colider.gameObject.CompareTag("Enemy") || colider.gameObject.CompareTag("Obstacle"))
        {
            // タイムの増加
            TimerManager timemanager = GameObject.FindGameObjectWithTag("Time").GetComponent<TimerManager>(); // マネージャーを取得
            timemanager.AddTime(-10);
            Destroy(colider.gameObject);
        }
    }
}
