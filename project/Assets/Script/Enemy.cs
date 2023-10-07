using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Vector3 m_move; // �ړ���

    private int m_DeadCount;

    // Start is called before the first frame update
    void Start()
    {
        m_DeadCount = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos += m_move;

        transform.position = pos;

        m_DeadCount--;

        if(m_DeadCount < 0)
        {
            Destroy(gameObject);
        }
    }
}
