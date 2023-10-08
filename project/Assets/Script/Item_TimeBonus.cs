using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_TimeBonus : MonoBehaviour
{
    [SerializeField]
    Vector3 m_move; // 移動量

    [SerializeField]
    float m_Life; // 寿命

    [SerializeField]
    float m_Bonus;    // ボーナス量

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // 座標の移動
        Vector3 pos = transform.position;
        pos += m_move * Time.deltaTime;
        transform.position = pos;

        // 寿命確認
        m_Life--;
        if(m_Life < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider colider)
    {
        // 敵かどうか確認
        if (colider.gameObject.CompareTag("Player"))
        {
            // タイムの増加
            TimerManager timemanager = GameObject.FindGameObjectWithTag("Time").GetComponent<TimerManager>(); // マネージャーを取得
            timemanager.AddTime(m_Bonus);

            // 自身を消す
            Destroy(gameObject);
        }
    }
}
