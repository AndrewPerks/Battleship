using System.ComponentModel;

namespace BattleshipModellingPractice
{
    public enum OccupationType
    {
        [Description("O")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("D")]
        Destroyer,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss
    }

    public enum ShotResult
    {
        Miss,
        Hit
    }
}
