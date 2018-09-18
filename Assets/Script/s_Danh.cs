using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_Danh : MonoBehaviour {
    public Button m_NutDanhQuai;
    public Button m_NutAutoTap;
    public float m_CritTime;
    public float m_CritChance;
    public Button m_NutPowerUp;
    public Text m_HienMauQuai;
    public Text m_TextTien;
    public int m_PhiTangDame;
    public float m_Tien = 0;
    public int m_Dame;
    public List<GameObject> m_ListEnemys;
    public bool isDead;
    public bool isDamaged;
    public int j = 0;
    // Use this for initialization
    void Start () {
        m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MaxHealth;
        for (int i = 0; i < m_ListEnemys.Count; i++)
        {
            m_ListEnemys[i].SetActive(false);
        }
        m_ListEnemys[0].SetActive(true);
        m_TextTien.text = "";
        Button NutDanhQuai = m_NutDanhQuai.GetComponent<Button>();
        Button NutPowerUp = m_NutPowerUp.GetComponent<Button>();
        Button NutAutoTap = m_NutAutoTap.GetComponent<Button>();
        NutDanhQuai.onClick.AddListener(hamDanhQuai);
        NutPowerUp.onClick.AddListener(hamTangDame);
        NutAutoTap.onClick.AddListener(()=> {
            StartCoroutine(autoTap());
        });
    }
	
	// Update is called once per frame
	void Update () {
        m_HienMauQuai.text = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth.ToString();
        m_TextTien.text = m_Tien.ToString();

    }
    public void hamDanhQuai()
    {
        Damaged();
        checkDead();
        isDamaged = false;
    }
    IEnumerator m_Delay(int index)
    {
        yield return new WaitForSeconds(0.25f);
        m_ListEnemys[index].SetActive(true);
        m_NutDanhQuai.gameObject.SetActive(true);
        m_HienMauQuai.gameObject.SetActive(true);
        m_ListEnemys[index].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth = m_ListEnemys[index].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth;
        m_ListEnemys[index].GetComponent<s_ThuocTinhQuai>().m_HealthBar.gameObject.SetActive(true);
        m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_HealthBar.value = 1f;
    }
    void setActiveEnemies(int index)
    {
        for (int i = 0; i < m_ListEnemys.Count; i++)
        {
            m_ListEnemys[i].SetActive(false);
            m_NutDanhQuai.gameObject.SetActive(false);
            m_HienMauQuai.gameObject.SetActive(false);
            m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_HealthBar.gameObject.SetActive(false);
        }
        StartCoroutine(m_Delay(index));
    }

    void Damaged()
    {
        isDamaged = true;
        float x = Random.Range(0f, 100f);
        if (x <= m_CritChance)
        {
            m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth - m_Dame * m_CritTime;
        }
        else
        {
            m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth - m_Dame;
        }
        m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_HealthBar.value = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth / (float)m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MaxHealth;
        m_ListEnemys[j].GetComponent<s_QuaiAnimation>().m_Damaged.SetBool("isDamaged", true);
    }
    void hamTangDame()
    {
        if (m_Tien >= m_PhiTangDame)
        {
            m_Dame = m_Dame + 2;
            m_Tien = m_Tien - m_PhiTangDame;
            m_PhiTangDame = m_PhiTangDame * 2;
        }
        else
        {
            Debug.Log("Khong Du Tien");
        }
    }

    IEnumerator autoTap()
    {
        for (int i = 0; i < 600; i++)
        {
            Damaged();
            checkDead();
            yield return new WaitForSeconds(0.05f);
        }
    }
    void checkDead()
    {
        if (m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth <= 0 && j < m_ListEnemys.Count)
        {
            if (j <= 8)
            {
                m_ListEnemys[j + 1].GetComponent<s_ThuocTinhQuai>().m_MaxHealth = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MaxHealth * 3;
                m_ListEnemys[j + 1].GetComponent<s_ThuocTinhQuai>().m_TienRot = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MaxHealth * 1.5f;
            }
            else
            {
                m_ListEnemys[j + 1].GetComponent<s_ThuocTinhQuai>().m_MaxHealth = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MaxHealth * 10;
                m_ListEnemys[j + 1].GetComponent<s_ThuocTinhQuai>().m_TienRot = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MaxHealth * 15f;
            }
            m_ListEnemys[j + 1].GetComponent<s_ThuocTinhQuai>().m_CurrentHealth = m_ListEnemys[j + 1].GetComponent<s_ThuocTinhQuai>().m_MaxHealth;
            //isDead = false;
            m_Tien = m_Tien + m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_TienRot;
            j++;

            setActiveEnemies(j);
        }
    }
}
