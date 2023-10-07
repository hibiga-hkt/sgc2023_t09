using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int m_SpawnCount;   // カウンター

    [SerializeField]
    private int m_SetTimer;     // 生成既定タイマー

    [SerializeField]
    private EnemyData[] m_aEnemy;  // 生成オブジェクト

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
        m_SpawnCount++;

        // 生成
        if(m_SpawnCount > m_SetTimer)
        {
            m_SpawnCount = 0;

            int nRand = Random.Range(MinRange, MaxRange);
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
    public Vector3 m_position;
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
    public Vector3 m_position;
}