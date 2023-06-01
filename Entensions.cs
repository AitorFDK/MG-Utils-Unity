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
    }
}