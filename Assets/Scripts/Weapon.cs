using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int level;

    public Transform originRef;

    public int damage;
    public float range;
    public float scale;
    public float speed;
    public Vector3 direction;
    public float actualLifeTime;
    public bool isPrepared = false;

    public Transform target;

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

    public void Preapare(Transform objRef, Transform enemyPos, float lifeTimeMax)
    {
        target = enemyPos;
        originRef = objRef;
        actualLifeTime = lifeTimeMax;
        lookingAt();

        isPrepared = true;
    }

    void lookingAt()
    {
        direction = target.position - originRef.position;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }


}
