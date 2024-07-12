public struct GridPos
{
    int x, z;
    public GridPos(int x, int z)
    {
        this.x = x; this.z = z;
    }
    override
    public string ToString()
    {
        return "x: " + x + "; z:" + z;
    }
}
