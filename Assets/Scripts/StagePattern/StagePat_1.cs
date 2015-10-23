using UnityEngine;
using System.Collections;

public class StagePat_1 : MonoBehaviour
{

    enum Phase
    {
        PHASE_NORMAL,
        PHASE_BOSS,
        PHASE_CLEAR,
    };

    public GameObject m_enemy1;
    public GameObject m_boss;

    public float m_tSpawnEnemy1;

    private Phase m_ePhase;
    private int m_nMobAlive;
    private float m_tUpdateTime;

    // Use this for initialization
    void Start()
    {
        if (m_enemy1 == null || m_boss == null)
            Debug.LogError("No GameObject");

        if (m_tSpawnEnemy1 <= 0)
            m_tSpawnEnemy1 = 2;

        m_ePhase = Phase.PHASE_NORMAL;
        m_nMobAlive = 0;                  // MobMan에서 array든 뭐든 생성한 애들 관리를 해야 하는데... 일단은 이렇게 구실을.
        m_tUpdateTime = Time.time;

        //CallEnemy();

    }

    // Update is called once per frame
    void Update()
    {

        switch (m_ePhase)
        {
            case Phase.PHASE_NORMAL:
                if (m_tUpdateTime + m_tSpawnEnemy1 < Time.time)
                {
                    if (m_nMobAlive == 0)
                    {
                        m_ePhase = Phase.PHASE_BOSS;
                        CallBoss();
                    }
                }
                break;
            case Phase.PHASE_BOSS:
                break;
            case Phase.PHASE_CLEAR:
                break;
            default:
                Debug.LogError("No Phase Info");
                break;
        }
    }

    void CallEnemy()
    {
        float x1 = -3.0f;
        float x2 = 3.0f;

        Instantiate(m_enemy1, new Vector3(Random.Range(x1, x2), transform.position.y, 0), Quaternion.identity);
        m_nMobAlive++;
    }

    void CallBoss()
    {
        float fBossY = 1;
        Instantiate(m_boss, new Vector3(0, fBossY, 0), Quaternion.identity);

        m_nMobAlive = 1;
    }
}
