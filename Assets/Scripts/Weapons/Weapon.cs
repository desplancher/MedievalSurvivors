using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform originRef;
    public Transform target;
    public Vector3 direction;

    public int actualDamage;
    public float actualRange;
    public float actualScale;
    public float actualSpeed;
    private float actualLifeTime;

    public bool isPrepared = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPrepared)
        {
            actualLifeTime -= Time.deltaTime;
        } 

        if (actualLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Preapare(Transform objRef, Transform enemyPos, float lifeTimeMax, int damage, float range, float scale, float speed)
    {
        target = enemyPos;
        originRef = objRef;
        actualLifeTime = lifeTimeMax;
        actualDamage = damage;
        actualRange = range;
        actualScale = scale;
        actualSpeed = speed;
        lookingAt();

        isPrepared = true;
    }

    void lookingAt()
    {
        direction = target.position - originRef.position;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageInEnemy(other);
    }

    void DamageInEnemy(Collider2D enemyCollider)
    {
        if (enemyCollider.CompareTag("Enemy"))
        {

            enemyCollider.GetComponent<Enemy>().TakeDamage(actualDamage);

        }
    }

}
