using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private int m_HeightCnt;   // 縦に存在する数

    private int m_nSpawnCnt = 0; // 合計生成数

    public int HeightCnt
    {
        get { return m_HeightCnt; }
        set { m_HeightCnt = value; }
    }

    public int SpawnCnt
    {
        get { return m_nSpawnCnt; }
        set { m_nSpawnCnt = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {// Escキーが押されたとき
            Quit();
        }

        Debug.Log(SpawnCnt);
    }

    // 終了
    void Quit()
    {
#if UNITY_EDITOR    // エディター
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE  // 実行
        UnityEngine.Application.Quit();
#endif
    }
}
