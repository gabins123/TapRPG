using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_ThuocTinhQuai : MonoBehaviour {
    public float m_MaxHealth;
    public float m_CurrentHealth;
    public Slider m_HealthBar;
    public float m_TienRot;
    void Awake()
    {
        m_HealthBar.value = 1f;

    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
}
