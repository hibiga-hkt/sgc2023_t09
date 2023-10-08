using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 m_move; // ??????

    [SerializeField]
    private float m_Speed;  // ???????x
    [SerializeField]
    private float m_fMulti; // ????
    [SerializeField]
    public GameObject particlePrefab; // パーティクルシステムのプレハブをInspectorから設定
    [SerializeField]
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsPlaying)
        {
            return;
        }

        // ??????????
        Vector3 pos = transform.position;   // ???????????W??????

        // ?????????????W??????
        Vector3 leftDown = Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width, -Screen.height)); // ?????????W
        Vector3 rightUp = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // ?E???????W

        // ?X?v???C?g????????????

        // ????
        if (Input.GetKey(KeyCode.A))
        {// A?L?[??????????????
            if (Input.GetKey(KeyCode.W))
            {// W?L?[??????????????
                m_move.x += Mathf.Sin(-Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(-Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {// S?L?[??????????????
                m_move.x += Mathf.Sin(-Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(-Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
            }
            else
            {// ????????????????????
                m_move.x += Mathf.Sin(-Mathf.PI * 0.5f) * m_Speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {// D?L?[??????????????
            if (Input.GetKey(KeyCode.W))
            {// W?L?[??????????????
                m_move.x += Mathf.Sin(Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {// S?L?[??????????????
                m_move.x += Mathf.Sin(Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
            }
            else
            {// ????????????????????
                m_move.x += Mathf.Sin(Mathf.PI * 0.5f) * m_Speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {// W?L?[??????????????
            m_move.y += Mathf.Cos(Mathf.PI * 0.0f) * m_Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {// S?L?[??????????????
            m_move.y += Mathf.Cos(Mathf.PI * 1.0f) * m_Speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // ?v???C???[??????
            kidsManager.SetAvoid();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // ?v???C???[??????
            kidsManager.SetFormation();
        }

        pos += m_move;   // ???????????Z

        // ??????????
        //pos.x = Mathf.Clamp(pos.x, leftDown.x, rightUp.x);
        //pos.y = Mathf.Clamp(pos.y, leftDown.y, rightUp.y);

        // ??????????
        m_move.x += (0.0f - m_move.x) * m_fMulti;   //x???W
        m_move.y += (0.0f - m_move.y) * m_fMulti;	//y???W

        // ???W?X?V
        transform.position = pos;

        transform.Translate(m_move.x, m_move.y, m_move.z, Space.World); // ???????????Z
    }

    private void OnTriggerEnter(Collider colider)
    {
        // ?G?????????m?F
        if (colider.gameObject.CompareTag("Enemy") || colider.gameObject.CompareTag("Obstacle"))
        {
            SoundManager.Instance.PlaySound(clip);
            // プレハブをインスタンス化
            GameObject particleSystemInstance = Instantiate(particlePrefab);

            // パーティクルシステムをアクティブにする
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();
            particleSystemInstance.transform.position = transform.position;
            particleSystem.Play();
            // ?^?C????????
            TimerManager timemanager = GameObject.FindGameObjectWithTag("Time").GetComponent<TimerManager>(); // ?}?l?[?W???[??????
            timemanager.AddTime(-2);
            Destroy(colider.gameObject);
        }
    }
}
