using System;

public struct GridPos : IEquatable<GridPos>
{
    public int x, z;

    public GridPos(int x, int z)
    {
        this.x = x; this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPos pos &&
               x == pos.x &&
               z == pos.z;
    }
    public bool Equals(GridPos other)
    {
        return this == other;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    override public string ToString()
    {
        return "x: " + x + "; z:" + z;
    }
    public static bool operator == (GridPos a, GridPos b)
    {
        return a.x == b.x && a.z == b.z;
    }
    public static bool operator != (GridPos a, GridPos b)
    {
        return a.x != b.x || a.z != b.z;
    }
}
