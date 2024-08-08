using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    public float variation;

    public Weapon mortalObject;
    // Start is called before the first frame update
    void Start()
    {
        variation = 0;
        mortalObject = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        variation += Time.deltaTime * mortalObject.actualSpeed;

        //Varia o X e o Y para gerar o movimento do circular, range aumenta a distancia em relação ao personagem
        float x = Mathf.Cos(variation) * mortalObject.actualRange;
        float y = Mathf.Sin(variation) * mortalObject.actualRange;


        transform.position = new Vector3(mortalObject.originRef.position.x - x, mortalObject.originRef.position.y - y, 0);

    }
}