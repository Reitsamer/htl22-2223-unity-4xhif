using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    public Rigidbody2D projectilePrefab;
    public float projectileSpeed;
    public float projectileLowerRange;
    public float projectileUpperRange;
    public float[] yPos = { 2.5f, -2.5f };
    void Start()
    {
        Invoke(nameof(Fire), 0f);
    }

    void Fire()
    {
        var parent = GetComponentInParent<Transform>();
        /*Vector3 scale = parent.localScale;
        if (parent.localScale.x < 0)
            transform.localScale = scale
            */
        var yPosVector = Vector3.up * yPos[Random.Range(0, yPos.Length)];
        Rigidbody2D projectile = Instantiate(projectilePrefab, transform.position + yPosVector, transform.rotation);
        
        projectile.AddForce(Vector2.left * projectileSpeed);
        Invoke(nameof(Fire), Random.Range(projectileLowerRange, projectileUpperRange));
        
    }
}
