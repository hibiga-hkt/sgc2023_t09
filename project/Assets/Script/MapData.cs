using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    [SerializeField]
    private int m_EnemySpawnCount;   // カウンター

    [SerializeField]
    private int m_FoodSpawnCount;

    [SerializeField]
    private int m_EnemySetTimer;     // 生成既定タイマー

    [SerializeField]
    private int m_FoodSetTimer;     // 生成既定タイマー

    [SerializeField]
    private EnemyData[] m_aEnemy;  // 生成敵オブジェクト

    [SerializeField]
    private FoodData[] m_aFood;  // 生成食オブジェクト

    [SerializeField]
    private int MinRange;       // 生成最低範囲

    [SerializeField]
    private int MaxRange;       // 生成最大範囲

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_EnemySpawnCount++;

        // 生成
        if(m_EnemySpawnCount > m_EnemySetTimer)
        {
            m_EnemySpawnCount = 0;

            int nRand = Random.Range(MinRange, MaxRange);

            Enemy enemy = Instantiate(m_aEnemy[nRand].m_prefab, m_aEnemy[nRand].position, Quaternion.identity).GetComponent<Enemy>();
        }

        m_FoodSpawnCount++;

        // 生成
        if (m_FoodSpawnCount > m_FoodSetTimer)
        {
            m_FoodSpawnCount = 0;

            int nRand = Random.Range(MinRange, MaxRange);

            food Food = Instantiate(m_aFood[nRand].m_prefab, m_aFood[nRand].position, Quaternion.identity).GetComponent<food>();
        }
    }
}

[System.Serializable]   // クラスのデータをインスペクタに表示させるために必要
public class EnemyData
{
    // 名前
    [HideInInspector]
    public string m_name;
    // [HideInInspector] インスペクタ上で非表示にする

    // 生成するプレハブ
    public GameObject m_prefab;

    // 出現位置
    public Vector3 position;
}

[System.Serializable]   // クラスのデータをインスペクタに表示させるために必要
public class FoodData
{
    // 名前
    [HideInInspector]
    public string m_name;
    // [HideInInspector] インスペクタ上で非表示にする

    // 生成するプレハブ
    public GameObject m_prefab;

    // 出現位置
    public Vector3 position;
}