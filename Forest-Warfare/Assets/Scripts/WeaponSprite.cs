using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSprite : MonoBehaviour
{
    List<Vector2> physicsShape = new List<Vector2>();
    public void SetSprite(string name)
    {
        if(Resources.Load<Sprite>("Weapons/" + name) == null)
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Weapons/" + name);
        GetComponent<SpriteRenderer>().sprite.GetPhysicsShape(0, physicsShape);
        GetComponent<PolygonCollider2D>().SetPath(0, physicsShape);
    }
}
