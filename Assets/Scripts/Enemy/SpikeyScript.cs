using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// Spikey class, just dealing damage to the player. 
/// </summary>
public class SpikeyScript : MonoBehaviour {

    public int dmg;

    private void Start()
    {
        DOTween.Init();    
        GetComponent<SpriteRenderer>().DOFade(1.0f, 2.5f);
        Destroy(gameObject, 15f);
        InvokeRepeating("ShakeItUp", 3, 2);
    }

    /// <summary>
    /// This will just give a small random animation to the Spike gameobject. Also the Kinematic is here, which is kind of inefficient but the reason of that line is so in the first few seconds the spikey will adjust itself. 
    /// </summary>
    void ShakeItUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        float rand = Random.Range(0.0f, 1.0f);
        if(rand > 0.5f)
        {
            transform.DOShakeScale(1, 0.4f, 7, 48, true);
        }
    }

    /// <summary>
    /// Deal damage to the player and yell "Thou Shall Not Pass"
    /// And also push the player aside as well. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().Damage(dmg);

            //Create a small push towards the opposite direction of impact. 
            Vector2 dir = collision.contacts[0].point - (Vector2)transform.position;
            dir = dir.normalized;
            Vector2 currentPosition = collision.gameObject.GetComponent<Rigidbody2D>().position;
            collision.gameObject.GetComponent<Rigidbody2D>().position = currentPosition + dir;

        }
    }
}
