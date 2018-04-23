using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    Texture2D[] frames;
    public float framesPerSecond;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond);
        index = index % frames.Length;
        renderer.material.mainTexture = frames[index];
    }
}