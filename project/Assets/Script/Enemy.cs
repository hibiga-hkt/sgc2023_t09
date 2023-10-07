using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SpawnEggsprefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            egg.Set(player.transform.position, new Vector3(-0.12f, 0.0f, 0.0f));

            // 自身を消す
            Destroy(gameObject);
        }
    }
}
