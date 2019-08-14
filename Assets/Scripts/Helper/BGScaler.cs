using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector2 offset = Vector2.zero;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        var height = Camera.main.orthographicSize * 2;
        var width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(width, height, 0);

        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");

    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
