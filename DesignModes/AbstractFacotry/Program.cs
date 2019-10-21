using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryBase bjWindfactory = new WindFactoryBJ();
            FactoryBase bjTempFactory = new TempFactoryBJ();
            LidarBase bjWindLidar = bjWindfactory.CreatLidar();
            bjWindLidar.CreateLidar();
            LidarBase bjTempLidar = bjTempFactory.CreatLidar();
            bjTempLidar.CreateLidar();
            AirPlaneBase bjWindPlane = bjWindfactory.CreatAirPlane();
            bjWindPlane.CreatePlane();
            AirPlaneBase bjTempPlane = bjTempFactory.CreatAirPlane();
            bjTempPlane.CreatePlane();
            FactoryBase shWindFactory = new WindFactorySH();
            FactoryBase shTempFactory = new TempFactorySH();
            LidarBase shWindLidar = shWindFactory.CreatLidar();
            shWindLidar.CreateLidar();
            LidarBase shTempLidar = shTempFactory.CreatLidar();
            shTempLidar.CreateLidar();
            AirPlaneBase shWindPlane = shWindFactory.CreatAirPlane();
            shWindPlane.CreatePlane();
            AirPlaneBase shTempPlane = shTempFactory.CreatAirPlane();
            shTempPlane.CreatePlane();
            Console.Read();

          
        }
    }
}
