using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    Vector3 m_move; // ˆÚ“®—Ê

    private int m_DeadCount;

    // Start is called before the first frame update
    void Start()
    {
        m_DeadCount = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos += m_move * Time.deltaTime;

        transform.position = pos;

        m_DeadCount--;

        if (m_DeadCount < 0)
        {
            Destroy(gameObject);
        }
    }
}
