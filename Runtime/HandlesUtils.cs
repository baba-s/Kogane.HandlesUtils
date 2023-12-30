using System.Diagnostics;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Kogane
{
    public static class HandlesUtils
    {
        [Conditional( "UNITY_EDITOR" )]
        public static void DrawRectangle
        (
            in Rect rect,
            Color   color,
            float   thickness
        )
        {
            DrawRectangle
            (
                position: rect.position,
                size: rect.size,
                color: color,
                thickness: thickness
            );
        }

        [Conditional( "UNITY_EDITOR" )]
        public static void DrawRectangle
        (
            in Vector3 position,
            in Vector2 size,
            Color      color,
            float      thickness
        )
        {
#if UNITY_EDITOR
            Handles.color = color;

            var halfSize = ( Vector3 )size * 0.5f;
            var min      = position - halfSize;
            var max      = position + halfSize;

            Handles.DrawLine( min, new( max.x, min.y, min.z ), thickness );
            Handles.DrawLine( min, new( min.x, max.y, min.z ), thickness );
            Handles.DrawLine( max, new( min.x, max.y, max.z ), thickness );
            Handles.DrawLine( max, new( max.x, min.y, min.z ), thickness );
#endif
        }
    }
}