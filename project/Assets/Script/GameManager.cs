using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private int m_HeightCnt;   // �c�ɑ��݂��鐔

    private int m_nSpawnCnt = 0; // ���v������

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
        {// Esc�L�[�������ꂽ�Ƃ�
            Quit();
        }

        Debug.Log(SpawnCnt);
    }

    // �I��
    void Quit()
    {
#if UNITY_EDITOR    // �G�f�B�^�[
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE  // ���s
        UnityEngine.Application.Quit();
#endif
    }
}
