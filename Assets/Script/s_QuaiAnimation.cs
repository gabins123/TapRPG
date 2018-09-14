using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_QuaiAnimation : MonoBehaviour {
    public Animator m_Damaged;
    public GameObject gameController;

	// Use this for initialization
	void Awake () {
        m_Damaged = GetComponent<Animator>();
	}
}
