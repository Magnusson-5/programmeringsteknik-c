using System;
using NGeoNames;
using NGeoNames.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace geocode
{
    class Program
    {
        const string _resourcePath = ".\\Resources\\SE.txt";
        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;

        static readonly (double lat, double lng) _gavlePosition = (60.674622, 17.141830);
        static readonly (double lat, double lng) _uppsalaPosition = (59.858562, 17.638927);

        static readonly IFormatProvider _formatProvider;
        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(_resourcePath);
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);

            _gavlePosition = (60.674622, 17.141830);
            _uppsalaPosition = (59.858562, 17.638927);

            _formatProvider = CultureInfo.InvariantCulture;
        }

        static void Main(string[] args)
        {
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            Console.WriteLine("-----------");
            Console.WriteLine("1. Gävle");
            Console.WriteLine("-----------");

            ListGavlePositions();

            Console.WriteLine("-----------");

            // 2. Hitta de 50 närmsta platserna inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            Console.WriteLine("2. Uppsala");
            Console.WriteLine("-----------");
           
            ListUppsalaPositions();

            Console.WriteLine("-----------");

            // 3. Lista x platser baserat på användarinmatning.
            Console.WriteLine("3. Inmatade positioner");
            Console.WriteLine("-----------");

            ListInputPositions(args);

        }

        static void ListGavlePositions()
        {
            var nearestGavle = _reverseGeoCodingService.RadialSearch(_gavlePosition.lat, _gavlePosition.lng, 10);


            nearestGavle = nearestGavle.OrderBy(p => p.Name);

            foreach (var position in nearestGavle)
            {
                Console.WriteLine($"{position.Name}, lat: {position.Latitude}, lng: {position.Longitude}");
            }
        }

        static void ListUppsalaPositions()
        {
            var nearestUppsala = _reverseGeoCodingService.RadialSearch(_uppsalaPosition.lat, _uppsalaPosition.lng, 200000d, 50);

            nearestUppsala = nearestUppsala.OrderBy(p => p.DistanceTo(_uppsalaPosition.lat, _uppsalaPosition.lng));


            foreach (var position in nearestUppsala)
            {
                var uppsalaDistance = position.DistanceTo(_uppsalaPosition.lat, _uppsalaPosition.lng);
                Console.WriteLine($"{position.Name}, distance to Uppsala: {(int)uppsalaDistance}m");
            }
        }

        static void ListInputPositions(string[] args)
        {
            double lat = double.Parse(args[0], _formatProvider);
            double lng = double.Parse(args[1], _formatProvider);

            var nearestUser = _reverseGeoCodingService.RadialSearch(lat, lng, 10);

            foreach (var position in nearestUser)
            {
                var userDistance = position.DistanceTo(lat, lng);
                Console.WriteLine($"{position.Name}, distance: {userDistance}");
            }
        }
    }
}
