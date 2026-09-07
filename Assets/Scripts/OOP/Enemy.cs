using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp = 100;
    public float ms = 2f;
    protected Transform Player;

    [Header("pengaturan State machine")]
    [SerializeField] private float jarakdeteksi = 6f; // masuk CHASE
    [SerializeField] private float jarakserang = 1.2f; // masuk ATTACK
    [SerializeField] private float jedaserang = 1f; // detik antar serang

    // state sekarang -- mulai dari IDLE
    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;
    protected virtual void Start()
    {
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            Player = PlayerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PeriksaTransisi();

        switch (state)
        {
            case StateZombie.IDLE: perilakuIdle(); break;
            case StateZombie.PATROL: perilakupatrol(); break;
            case StateZombie.CHASE: perilakuchase(); break;
            case StateZombie.ATTACK: perilakuattack(); break;
        }
    }

    public void kejar()
    {
        if (Player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            Player.position,
            ms * Time.deltaTime
        );
    }
    public virtual void Serang()
    {
        Debug.Log("Enemy Menyerang");
    }

    public float Jarakkeplayer()
    {
        if (Player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, Player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = Jarakkeplayer();

        if (jarak <= jarakserang)
            state = StateZombie.ATTACK; // sangat dekat -> serang
        else if(jarak <= jarakdeteksi)
            state = StateZombie.CHASE; // terlihat -> kejar
        else
            state = StateZombie.PATROL; // jauh -> keliling
    }

    void perilakuIdle()
    {
        Debug.Log("zombies idle");
    }

    void perilakuattack()
    {
        Debug.Log("zombies attack");
    }

    void perilakuchase()
    {
        Debug.Log("zombies chase");
        kejar();
    }

    void perilakupatrol()
    {
        Debug.Log("zombies sedang patroli");
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        if (hp <= 0)
        {
            Mati();
        }
    }

    private void Mati()
    {
        Debug.Log($"{gameObject.name} Mati");
        Destroy(gameObject);
    }
}