using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_Danh : MonoBehaviour {
    public Button m_NutDanhQuai;
    public Text m_HienMauQuai;
    public int m_Dame;
    public List<GameObject> m_ListEnemys;
    public int j = 0;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < m_ListEnemys.Count; i++)
        {
            m_ListEnemys[i].SetActive(false);
        }
        m_ListEnemys[0].SetActive(true);

        Button NutDanhQuai = m_NutDanhQuai.GetComponent<Button>();
        NutDanhQuai.onClick.AddListener(hamDanhQuai);
    }
	
	// Update is called once per frame
	void Update () {
        m_HienMauQuai.text = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MauQuai.ToString();

    }
    void hamDanhQuai()
    {
        m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MauQuai = m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MauQuai - m_Dame;
        if (m_ListEnemys[j].GetComponent<s_ThuocTinhQuai>().m_MauQuai <= 0 && j < m_ListEnemys.Count)
        {
            setActiveEnemies(j);
            j++;
        }
    }
    IEnumerator m_Delay(int index)
    {
        yield return new WaitForSeconds(0.25f);
        m_ListEnemys[index].SetActive(true);
        m_NutDanhQuai.gameObject.SetActive(true);
        m_HienMauQuai.gameObject.SetActive(true);
        m_ListEnemys[index].GetComponent<s_ThuocTinhQuai>().m_MauQuai = m_ListEnemys[index].GetComponent<s_ThuocTinhQuai>().m_MauQuai;
    }
    void setActiveEnemies(int index)
    {
        for (int i = 0; i < m_ListEnemys.Count; i++)
        {
            m_ListEnemys[i].SetActive(false);
            m_NutDanhQuai.gameObject.SetActive(false);
            m_HienMauQuai.gameObject.SetActive(false);
        }
        StartCoroutine(m_Delay(index));
    }
}
