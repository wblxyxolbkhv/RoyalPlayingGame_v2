using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Utils
{
    public static class Extensions
    {
        public static float UnitsPerPixel(this Camera cam)
        {
            var p1 = cam.ScreenToWorldPoint(Vector3.zero);
            var p2 = cam.ScreenToWorldPoint(Vector3.right);
            return Vector3.Distance(p1, p2);
        }

        public static float PixelsPerUnit(this Camera cam)
        {
            return 1 / UnitsPerPixel(cam);
        }
    }
}
