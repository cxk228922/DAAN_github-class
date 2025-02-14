using UnityEngine;

public class ScaleCube : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float scaleSpeed = 5f;
    public float maxScale = 5f;
    public float minScale = 2f;

    // Update is called once per frame
    void Update()
    {
        float scale = (Mathf.Sin(Time.time * scaleSpeed) + 1) * 0.5f * (maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale,scale,scale);
    }
}
