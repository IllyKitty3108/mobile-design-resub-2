using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 [RequireComponent(typeof(BoxCollider2D))]
public class puzzle : MonoBehaviour
{
  
private void Start()
{
    Shuffle();
}
 
private void OnMouseDown()
{
    Rotate();
}
 
private void Shuffle()
{
    float randomAngle = 90 * Random.Range(1, 4);

    transform.Rotate(new Vector3(0f, 0f, randomAngle));
}
 
private void Rotate()
{
    transform.Rotate(new Vector3(0f, 0f, -90f));
}
 
}