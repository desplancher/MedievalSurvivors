using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    public float timer;

    public Weapon mortalObject;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        mortalObject = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * mortalObject.speed;
        float x = Mathf.Cos(timer) * mortalObject.range;
        float y = Mathf.Sin(timer) * mortalObject.range;
        transform.position = new Vector3(mortalObject.originRef.position.x - x, mortalObject.originRef.position.y - y, 0);
    }
}
