using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {
   
    public enum EnemyType
    {
        Enemy1,
        Enemy2
    }
    public GameObject bulletPrefab;
    public float shootAngle = 30;
    public float shootingSpeed = 4.0f;

    public EnemyType enemy;

    private Transform playerTransform;
    private Vector2 targetPlace;

    private SpriteRenderer spriteRenderer;

    private Animator anim; 
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.Find("RoboWarrior").transform;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (enemy == EnemyType.Enemy1)
        {
            //Invoke the parabolic shooter function
            InvokeRepeating("ParabolicShooter", 2, 7);
        }
        if(enemy == EnemyType.Enemy2)
        {
            InvokeRepeating("StraightShooter", 2, 7);
        }

	}

    private void Update()
    {
        //Debug.Log(transform.position.x - playerTransform.position.x);
        float dist = transform.position.x - playerTransform.position.x;
        bool flipSprite = (spriteRenderer.flipX ? (dist > 0.01f) : (dist < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    void StraightShooter()
    {
        //Bullet is instantiated! 
        anim.SetTrigger("attacked");

        Invoke("ShootStraightBullet", 0.5f);
    }

    void ShootStraightBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().spawnSpikey = false;
        targetPlace = playerTransform.position;
        bullet.GetComponent<Rigidbody2D>().isKinematic = true;
        bullet.GetComponent<Rigidbody2D>().velocity = StraightVel(targetPlace, shootingSpeed);
        Destroy(bullet, 4.0f);
    }
	
	void ParabolicShooter()
    {
        //Bullet is instantiated! 
        anim.SetTrigger("attacked");
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0,0.2f,0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().spawnSpikey = true;
        targetPlace = playerTransform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = BallisticVel(targetPlace, shootAngle);
        Destroy(bullet, 4.0f);
    }

    Vector2 StraightVel(Vector2 targetPlace, float shootingSpeed)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = targetPlace - currentPosition;

        return shootingSpeed * direction.normalized;
    }


    Vector2 BallisticVel(Vector2 targetPlace, float shootingAngle)
    {
        
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = targetPlace - currentPosition;
        float height = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float angle = shootingAngle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(angle);
        distance += height / Mathf.Tan(angle);
        
        float finalVel = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * angle));
        return finalVel * direction.normalized;

    }


}
