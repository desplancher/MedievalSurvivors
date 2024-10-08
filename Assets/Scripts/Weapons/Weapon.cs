using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{

    public Transform originRef;
    public Vector3 target;
    public Vector3 direction;

    public int actualDamage;
    public float actualRange;
    public float actualScale;
    public float actualSpeed;
    public float actualArea;
    private float actualLifeTime;

    public bool canGiveDamage = true;
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

    /// <summary>
    /// Prepara o Objeto que foi instanciado de acordo com os parametros repassados.
    /// </summary>
    /// <param name="objRef">Transform do Objeto de partida, usado para definir a dire��o de sa�da do disparo.</param>
    /// <param name="enemyPos">Transform do Objeto de destido, usado para definir a dire��o de chegada do disparo</param>
    /// <param name="lifeTimeMax">Tempo de vida do disparo</param>
    /// <param name="damage">Dano do disparo</param>
    /// <param name="range">Distancia do disparo em rela��o ao Player</param>
    /// <param name="scale">Tamanho do disparo</param>
    /// <param name="speed">Velocidade do disparo</param>
    public void Preapare(Transform objRef, Vector3 enemyPos, float lifeTimeMax, int damage, float range, float scale, float speed)
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
        direction = target - originRef.position;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // DamageInEnemy(other);
        GiveDamage(other);

    }

    void GiveDamage(Collider2D enemyCollider)
    {
        if (enemyCollider.CompareTag("Enemy") && canGiveDamage)
        {
            
            enemyCollider.GetComponent<Enemy>().TakeDamage(actualDamage);

        }
    }

}