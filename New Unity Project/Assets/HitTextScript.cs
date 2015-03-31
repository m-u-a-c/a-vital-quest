using System;
using UnityEngine;
using System.Collections;

public class HitTextScript : MonoBehaviour
{
    private Color _col;
    private Timer _timer;
    void Start()
    {
        _timer = gameObject.AddComponent<Timer>();
        _timer.SetTimer(0.05f, 10, Tick);
        _col = gameObject.GetComponent<TextMesh>().color;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50);
    }

    void Tick()
    {
        _col = gameObject.GetComponent<TextMesh>().color;
        gameObject.GetComponent<TextMesh>().color = new Color(_col.r, _col.g, _col.b, _col.a - 0.1f);
        if (_timer.ticks == 10) Destroy(gameObject);
    }
}
