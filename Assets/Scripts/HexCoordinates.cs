using UnityEngine;

[System.Serializable]
public class HexCoordinates
{
    [SerializeField]
    private int x, z;

    public int Y
    {
        get 
        {
            return -X - Z;
        }
    }

    public int X 
    {
        get
        {
            return x;
        }
    }

    public int Z
    {
        get
        {
            return z;
        }
    }

    public HexCoordinates (int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public static HexCoordinates FromPosition(Vector3 position)
    {
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;

        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x - y);

        if (iX + iY + iZ != 0)
        {
            int dX = Mathf.RoundToInt(x - iX);
            int dY = Mathf.RoundToInt(y - iY);
            int dZ = Mathf.RoundToInt(-x - y -iZ);

            // reconstruct coordinates from the other two
            if (dX > dY && dX > dZ)
            {
                iX = -iY -iZ;
            }
            else if(dZ > dY)
            {
                iZ = -iX - iY;
            }
        }

        return new HexCoordinates(iX, iZ);
    }

    public override string ToString ()
    {
        return string.Format ("{0}, {1}, {2}", X, Y, Z);
    }

    public string ToStringOnSeparateLines ()
    {
        return string.Format ("{0}\n{1}\n{2}", X, Y, Z);
    }
}
