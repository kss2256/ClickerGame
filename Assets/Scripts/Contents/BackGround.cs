using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public class BackGround : MonoBehaviour
{
    private void Awake()
    {
        //¿¬±¸
        Camera cam = Camera.main;

        float targetAspect = 9f / 16f;
        float currentAspect = cam.aspect;

        cam.orthographicSize = 5f *
            Mathf.Max(1f, targetAspect / currentAspect);
    }

    private void Start()
    {

        BGScreenAdjustment();

        

    }



    public void BGScreenAdjustment()
    {
        Camera cam = Camera.main;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float cameraHeight = cam.orthographicSize * 2f;
        float cameraWidth = cameraHeight * cam.aspect;


        Vector2 spriteSize = sr.sprite.bounds.size;


        float scale = Mathf.Max(
            cameraWidth / spriteSize.x,
            cameraHeight / spriteSize.y
        );


        transform.localScale = new Vector3(scale, scale, 1f);
        
    }




}