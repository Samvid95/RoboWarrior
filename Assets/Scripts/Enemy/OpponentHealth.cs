using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHealth : MonoBehaviour {
    public int health = 40;

    public delegate void NoHealth();
    public static event NoHealth OnZeroHealth;

    private Color originalColor;

	// Use this for initialization
	void Start () {
        originalColor = GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            if(OnZeroHealth != null)
            {
                OnZeroHealth();
            }
            Destroy(gameObject);
        }
	}

    public void Damage(int damage)
    {
        health -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ResetColor", 0.2f);
    }

    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
