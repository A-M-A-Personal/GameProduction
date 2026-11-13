using UnityEngine;

public class Blob : EnemyMovement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);
        if (col.gameObject.tag == "NeedleTarget")
        {
            Stats.needleHealth--;
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Stats.health--;
            Destroy(gameObject);
        }

    }
}
