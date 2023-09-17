public class GridObject
{
    private Grid<GridObject> _grid;
    private int _x;
    private int _z;

    public GridObject(Grid<GridObject> grid, int x, int z)
    {
        _grid = grid;
        _x = x;
        _z = z;
    }

    public override string ToString()
    {
        return _x + ", " + _z + "\n";
    }
}