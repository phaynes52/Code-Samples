using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Assignment3 {
    /// <summary>
    /// This script should not be modified by the student.
    /// </summary>
    public class BallManager : MonoBehaviour {
        public enum BallType { Basketball, Volleyball, Fireball, Pokeball, DragonBall, BaldBall };
        [Tooltip("Select ball to display.")]
        public BallType ballType;

        private const string basePath = "Assets/Sprites/Balls/";

        private Dictionary<BallType, Sprite> sprites;
        private List<SpriteRenderer> spriteRenderers;

        private void OnValidate() {
            if (sprites == null || sprites.Count == 0) InitSprites();
            if (spriteRenderers == null || spriteRenderers.Count == 0) InitSpriteRenderers();

            SetSprites();
        }

        private void SetSprites() {
            Sprite sprite = sprites[ballType];
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                renderer.sprite = sprite;
            }
        }

        private void InitSprites() {
            sprites = new Dictionary<BallType, Sprite>();
            sprites.Add(BallType.BaldBall, AssetDatabase.LoadAssetAtPath<Sprite>(basePath + "Bald Ball.png"));
            sprites.Add(BallType.Basketball, AssetDatabase.LoadAssetAtPath<Sprite>(basePath + "Basketball.png"));
            sprites.Add(BallType.DragonBall, AssetDatabase.LoadAssetAtPath<Sprite>(basePath + "Dragon Ball.png"));
            sprites.Add(BallType.Fireball, AssetDatabase.LoadAssetAtPath<Sprite>(basePath + "Fireball.png"));
            sprites.Add(BallType.Pokeball, AssetDatabase.LoadAssetAtPath<Sprite>(basePath + "Pokeball.png"));
            sprites.Add(BallType.Volleyball, AssetDatabase.LoadAssetAtPath<Sprite>(basePath + "Volleyball.png"));
        }

        private void InitSpriteRenderers() {
            spriteRenderers = new List<SpriteRenderer>();
            foreach(SpriteRenderer renderer in FindObjectsOfType<SpriteRenderer>()) {
                if (renderer.name.ToLower().Contains("ball")) {
                    spriteRenderers.Add(renderer);
                }
            }
        }
    }
}
