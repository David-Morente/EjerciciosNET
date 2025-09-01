using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString()
        {
            try
            {
                int num = 0;

                WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();

                string result = worldsDumbest.ReturnsPikachuIfZero(num);

                if(result == "PIKACHU!")
                {
                    Console.WriteLine("Prueba aprobada: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnString");
                }
                else
                {
                    Console.WriteLine("Prueba fallida: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnString");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
