using UnityEngine;

public class SpinCube : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 RotateAmount;
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        InvokeRepeating("ChangeColor", 100f, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);
        ChangeColor();
    }
    void ChangeColor()
    {
        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}

