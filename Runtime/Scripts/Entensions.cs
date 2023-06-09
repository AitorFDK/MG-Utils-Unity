using System.Collections.Generic;
using UnityEngine;

namespace MendiGames.Utils
{
    public static class Entensions
    {
        /* -------------------------- COLLECTION EXTENSIONS ------------------------- */

        public static T GetRandom<T> (this List<T> list) {
            if (list == null || list.Count == 0) return default(T);
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandom<T> (this T[] array) {
            if (array == null || array.Length == 0) return default(T);
            return array[Random.Range(0, array.Length)];
        }

        public static T[] Shuffle<T>(this T[] array)
        {
            System.Random rng = new System.Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            return array;
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
        
        /* --------------------------- VECTOR 2 EXTENSIONS -------------------------- */

        public static Vector2 RotateAround (this Vector2 point, Vector2 pivot, float radians) {

            // calculate sin and cos of angle
            float s = Mathf.Sin(radians);
            float c = Mathf.Cos(radians);

            // move point to origin
            point.x -= pivot.x;
            point.y -= pivot.y;

            // rotate point
            float x = point.x * c - point.y * s;
            float y = point.x * s + point.y * c;

            // translate point back
            point.x = x + pivot.x;
            point.y = y + pivot.y;

            return point;
        }

        public static Vector2 RotateAroundEulers (this Vector2 point, Vector2 pivot, float eulers) {
            return RotateAround(point, pivot, eulers * Mathf.Deg2Rad);
        }

        /* --------------------------- VECTOR 3 EXTENSIONS -------------------------- */

        public static Vector2 xy (this Vector3 v) => new Vector2(v.x, v.y);
        public static Vector2 xz (this Vector3 v) => new Vector2(v.x, v.z);
        public static Vector2 yx (this Vector3 v) => new Vector2(v.y, v.x);
        public static Vector2 yz (this Vector3 v) => new Vector2(v.y, v.z);
        
        /* --------------------------- TEXTURE EXTENSIONS --------------------------- */
        
        public static Texture2D[] SpliceTexture(this Texture2D t, int subdivisions)
        {
            Texture2D[] textures = new Texture2D[subdivisions * subdivisions];

            int spliceWidth = t.width / subdivisions;
            int spliceHeight = t.height / subdivisions;
            int nTextures = 0;

            for (int j = subdivisions - 1; j >= 0; j--)
            {
                for (int i = 0; i < subdivisions; i++)
                {
                    Color[] colors = t.GetPixels((i) * spliceWidth, (j) * spliceHeight, spliceWidth, spliceHeight);

                    Texture2D aux = new Texture2D(spliceWidth, spliceHeight);
                    aux.name = nTextures.ToString();
                    aux.SetPixels(colors);
                    aux.Apply();

                    textures[nTextures] = aux;

                    nTextures++;
                }
            }

            return textures;
        }
    }
}
