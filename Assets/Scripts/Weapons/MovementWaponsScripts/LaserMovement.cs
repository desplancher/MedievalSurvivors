using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public Weapon mortalObject;
    public float maxArea = 0.3f;
    public float minArea = 0.09f;
    public float loadingValue;
    private bool isFiring = false;
    public float aceleration;

    private void Awake()
    {
        transform.localScale = new Vector3(transform.localScale.x, minArea, transform.localScale.z);
    }
    // Start is called before the first frame update
    void Start()
    {

        mortalObject = GetComponent<Weapon>();
        mortalObject.canGiveDamage = false;
    }

    // Update is called once per frame
    void Update()
    {

        LoadLaser();
        transform.position = mortalObject.originRef.position;
        
    }

    public void LoadLaser()
    {
        if(loadingValue > 0)
        {
            loadingValue -= Time.deltaTime;
        }
        else
        {
            mortalObject.canGiveDamage = true;
            EnterFiring();
        }
    }

    public void EnterFiring()
    {
        if(transform.localScale.y < maxArea)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + aceleration * Time.deltaTime, transform.localScale.z);
            aceleration += aceleration * 0.02f;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, maxArea, transform.localScale.z);
        }
    }


}
