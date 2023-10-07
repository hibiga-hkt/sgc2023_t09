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
        // �G���ǂ����m�F
        if (colider.gameObject.CompareTag("Player"))
        {
            // �v���C���[�����ʒu�܂ł̍X�V
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[���擾
            GameManager gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); // �}�l�[�W���[���擾

            // ������
            GameObject obj = Instantiate(m_SpawnEggsprefab, transform.position, Quaternion.identity);

            Egg egg = obj.GetComponent<Egg>();
            egg.Set(player.transform.position, new Vector3(-0.12f, 0.0f, 0.0f));

            // ���g������
            Destroy(gameObject);
        }
    }
}
