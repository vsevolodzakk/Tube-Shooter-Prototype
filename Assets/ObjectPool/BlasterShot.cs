using UnityEngine;

public class BlasterShot : MonoBehaviour, IGameObjectPooled
{
    public float moveSpeed = 50f;

    private float lifeTime;
    private float maxLifetime = 2f;

    // Простая реализация
    //public GameObjectPool Pool { get; set; }

    // Сложная реализация для обработки ошибки
    private GameObjectPool pool;
    public GameObjectPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
                pool = value;
            else
                throw new System.Exception("Bad pool use!");
        }
    }

    private void OnEnable()
    {
        lifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if(lifeTime > maxLifetime)
        {
            Pool.ReturnToPool(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //lifeTime = maxLifetime;
            Pool.ReturnToPool(this.gameObject);
            Debug.Log("HIT");
        }
    }
}
