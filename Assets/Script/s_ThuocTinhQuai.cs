using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_ThuocTinhQuai : MonoBehaviour {
    public int m_MaxHealth;
    public int m_CurrentHealth;
    public Slider m_HealthBar;
    void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
        m_HealthBar.value = 1f;
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
