namespace _355_Easy {
    public interface ILookupTable {
        char LookupCell(char column, char row);
        char LookupRow(char column, char value);
        char LookupColumn(char row, char value);
    }
}