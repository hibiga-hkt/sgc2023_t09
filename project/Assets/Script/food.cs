using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SpawnEggsprefab;

    [SerializeField]
    Vector3 m_move; // 移動量
  
    [SerializeField]
    AudioClip clip;
    private int m_Life;

    // Start is called before the first frame update
    void Start()
    {
        m_Life = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        pos += m_move * Time.deltaTime;

        transform.position = pos;

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
            // プレイヤーから定位置までの更新
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // プレイヤーを取得
            GameManager gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); // マネージャーを取得

            // 卵生成
            GameObject obj = Instantiate(m_SpawnEggsprefab, transform.position, Quaternion.identity);

            Egg egg = obj.GetComponent<Egg>();
            egg.Set(player.transform.position, new Vector3(-20.12f, 0.0f, 0.0f));
            SoundManager.Instance.PlaySound(clip);
            // 自身を消す
            Destroy(gameObject);
        }
    }
}
