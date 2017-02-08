using System.Device.Location;

namespace CSharp.Helpers.Helpers
{
    public class GeographyHelper
    {
        /// <summary>
        /// Calculate the distance between two places
        /// </summary>
        /// <param name="vonLatitude"></param>
        /// <param name="vonLongitude"></param>
        /// <param name="bisLatitude"></param>
        /// <param name="bisLongitude"></param>
        /// <returns></returns>
        public static double GetDistance(double vonLatitude, double vonLongitude, double bisLatitude, double bisLongitude)
        {
            var vonCoord = new GeoCoordinate(vonLatitude, vonLongitude);
            var bisCoord = new GeoCoordinate(bisLatitude, bisLongitude);
            return vonCoord.GetDistanceTo(bisCoord);
        }
    }
}
