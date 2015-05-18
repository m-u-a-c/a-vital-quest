using UnityEngine;
using System.Collections;
using System.Linq;

public class LaserScript : MonoBehaviour
{

    public LayerMask enemies;
    Timer timer;
    float yscale;
    public bool Right;
    // Use this for initialization
    void Start()
    {
        AudioSource.PlayClipAtPoint(GameObject.Find("Player").GetComponent<Pattacks>().lazerUse, gameObject.transform.position);
        timer = gameObject.AddComponent<Timer>();
        timer.SetTimer(0.05f, 10, Tick);
        yscale = gameObject.transform.localScale.x;
    }
    void Tick()
    {
        if (timer.ticks == 1)
            DoDamage();
        if (timer.ticks == 10)
            Destroy(gameObject);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, yscale - (0.1f * timer.ticks * yscale), gameObject.transform.localScale.y);
    }

    private void DoDamage()
    {
        var pstats = GameObject.Find("Player").GetComponent<Pstats>();
        var bounds = gameObject.GetComponent<Renderer>().bounds.center;
        var pos = GameObject.Find("Player").transform.position;
        Collider2D[] hit = null;
        hit = Physics2D.OverlapAreaAll(new Vector2(Right ? pos.x + 1 : pos.x - 1, 2 + pos.y - 0.5f), 
                                       new Vector2(Right ? pos.x + 22.5f : pos.x - 22.5f, pos.y - 1 + 0.5f), 
                                       LayerMask.GetMask("Enemies"));

        //if (!Right) hit = Physics2D.OverlapAreaAll(new Vector2(pos.x - bounds.x / 1.2f, pos.y + bounds.y / 1.2f), new Vector2(pos.x + bounds.x / 2, pos.y - bounds.y / 2), LayerMask.GetMask("Enemies"));
        //else hit = Physics2D.OverlapAreaAll(new Vector2(pos.x - bounds.x / 1.2f, pos.y + bounds.y / 1.2f), new Vector2(pos.x + bounds.x / 2, pos.y - bounds.y / 2), LayerMask.GetMask("Enemies"));
        if (hit.Length <= 0) return;

        var hitgos = new System.Collections.Generic.List<int>();
        foreach (var coll in hit.Where(coll => !hitgos.Contains(coll.gameObject.GetInstanceID())))
        {
            hitgos.Add(coll.gameObject.GetComponent<Estats>().getHit((pstats.sDamage) + 3, false));
        }
    }

}
