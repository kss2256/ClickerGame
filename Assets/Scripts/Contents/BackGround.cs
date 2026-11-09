using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public class BackGround : MonoBehaviour
{


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
        transform.position += Vector3.up * -0.8f;
    }




}