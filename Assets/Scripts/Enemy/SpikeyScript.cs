using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpikeyScript : MonoBehaviour {

    public int dmg = 20;

    private void Start()
    {
        DOTween.Init();
        GetComponent<SpriteRenderer>().DOFade(1.0f, 2.5f);
        InvokeRepeating("ShakeItUp", 3, 2);
    }

    void ShakeItUp()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if(rand > 0.5f)
        {
            transform.DOShakeScale(1, 0.4f, 7, 48, true);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This is for the bullet! 
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().Damage(dmg);
        }
    }
}
