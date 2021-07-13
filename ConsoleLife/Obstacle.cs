namespace Life
{
    public class Obstacle : Cell
    {
        public static string DefaultObstacleImg { get { return "#"; } }

        public Obstacle(Coordinate coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
