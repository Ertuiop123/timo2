using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public float speed = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        Vector2 move = new Vector2(x, y);

        transform.Translate(move);

    }
}
