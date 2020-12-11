using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float backgroundScrollSpeed = 0.5f;
    private Material myMaterial;
    private Vector2 offset;

    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundScrollSpeed);
    }

    private void Update()
    {
        myMaterial.mainTextureOffset += (offset * Time.deltaTime);
    }
}