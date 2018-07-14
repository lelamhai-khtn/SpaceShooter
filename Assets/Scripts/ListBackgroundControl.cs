using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBackgroundControl : MonoBehaviour {
    public float Speed = 1;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Direction Dir = Direction.Right;


    private float heightCamera;
    private float widthCamera;

    private Vector3 PositionCam;
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        heightCamera = 2f * cam.orthographicSize;
        widthCamera = heightCamera * cam.aspect;

        foreach (var item in sprites)
        {
            var sr = item.GetComponent<SpriteRenderer>();
            if (sr == null) return;

            ///item.transform.localScale = new Vector3(1, 1, 1);
            var width = sr.sprite.bounds.size.x;
            var height = sr.sprite.bounds.size.y;

            var worldScreenHeight = Camera.main.orthographicSize * 2.0;
            var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            Vector2 scale = transform.localScale;

            scale.x = (float)worldScreenWidth / width;
            scale.y = (float)worldScreenHeight / height;

            item.transform.localScale = Vector2.zero;

            item.transform.localScale = scale;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        foreach (var item in sprites)
        {
            if (Dir == Direction.Left)
            {
                if (item.transform.position.x + item.bounds.size.x / 2 < cam.transform.position.x - widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x > sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x + (sprite.bounds.size.x / 2) + (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }
            else if (Dir == Direction.Right)
            {
                if (item.transform.position.x - item.bounds.size.x / 2 > cam.transform.position.x + widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x < sprite.transform.position.x)
                            sprite = i;
                    }
                    item.transform.position = new Vector2((sprite.transform.position.x - (sprite.bounds.size.x / 2) - (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }
            else if (Dir == Direction.Down)
            {
                // - position + image position /2 < -5
                if (item.transform.position.y + item.bounds.size.y / 2 < cam.transform.position.y - heightCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.y > sprite.transform.position.y)
                        {
                            sprite = i;
                        }
                    }
                    item.transform.position = new Vector2(sprite.transform.position.x, (sprite.transform.position.y + (sprite.bounds.size.y / 2) + (item.bounds.size.y / 2)));
                }
            }
            else if (Dir == Direction.Up)
            {
                if (item.transform.position.y - item.bounds.size.y / 2 > cam.transform.position.y + heightCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.y < sprite.transform.position.y)
                            sprite = i;
                    }

                    item.transform.position = new Vector2(sprite.transform.position.x, (sprite.transform.position.y - (sprite.bounds.size.y / 2) - (item.bounds.size.y / 2)));
                }
            }
            if (Dir == Direction.Left)
                item.transform.Translate(new Vector2(Time.deltaTime * Speed * -1, 0));
            else if (Dir == Direction.Right)
                item.transform.Translate(new Vector2(Time.deltaTime * Speed, 0));
            else if (Dir == Direction.Down)
                item.transform.Translate(new Vector2(0, Time.deltaTime * Speed * -1));
            else if (Dir == Direction.Up)
                item.transform.Translate(new Vector2(0, Time.deltaTime * Speed));
        }
    }
  

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
