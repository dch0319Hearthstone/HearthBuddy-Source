﻿namespace Triton.Common.Math
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Point : IEquatable<Point>
    {
        public int X;
        public int Y;
        private static readonly Point _zero;
        public static Point Zero
        {
            get
            {
                return _zero;
            }
        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Point other)
        {
            return ((this.X == other.X) && (this.Y == other.Y));
        }

        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Point)
            {
                flag = this.Equals((Point) obj);
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return (this.X.GetHashCode() + this.Y.GetHashCode());
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            object[] args = new object[] { this.X.ToString(currentCulture), this.Y.ToString(currentCulture) };
            return string.Format(currentCulture, "{{X:{0} Y:{1}}}", args);
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            if (a.X == b.X)
            {
                return (a.Y != b.Y);
            }
            return true;
        }

        static Point()
        {
            _zero = new Point();
        }
    }
}

