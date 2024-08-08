using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public Weapon mortalObject;
    // Start is called before the first frame update
    void Start()
    {
        mortalObject = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = mortalObject.actualSpeed * Vector3.right;

        transform.Translate(speed * Time.deltaTime, Space.Self);
    }

    
}
