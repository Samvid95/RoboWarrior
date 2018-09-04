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
        GetComponent<Rigidbody2D>().isKinematic = true;
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
            Vector2 dir = collision.contacts[0].point - (Vector2)transform.position;
            dir = dir.normalized;
            collision.gameObject.GetComponent<PlayerHealthManager>().Damage(dmg);
            //Vector2 currentPos = collision.gameObject.GetComponent<Rigidbody2D>().position + dir * force;
            //collision.gameObject.GetComponent<Rigidbody2D>().MovePosition(currentPos);
            Vector2 currentPosition = collision.gameObject.GetComponent<Rigidbody2D>().position;
            collision.gameObject.GetComponent<Rigidbody2D>().position = currentPosition + dir;

        }
    }
}
