using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsProgram;
using System.Collections.Generic;
using System;

namespace MarsProblemTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() //Case e-postasýnda verilen ilk test
        {
            Rover rover = new Rover()
            {
                X = 1,
                Y = 2,
                Dir = Cardinals.N
            };
            var area_coordinates = new List<int>() { 5, 5 };
            var commands = "LMLMLMLMM"; 
            rover.Move(commands,area_coordinates);
            var output = rover.X + " " + rover.Y + " " + rover.Dir;
            var expected = "1 3 N";
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void TestMethod2() //Case e-postasýnda verilen ikinci test
        {
            Rover rover = new Rover()
            {
                X = 3,
                Y = 3,
                Dir = Cardinals.E
            };
            var area_coordinates = new List<int>() { 5, 5 };
            var commands = "MMRMMRMRRM";
            rover.Move(commands, area_coordinates);
            var output = rover.X + " " + rover.Y + " " + rover.Dir;
            var expected = "5 1 E";
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void TestMethod3() //Sonuç testi
        {
            Rover rover = new Rover()
            {
                X = 4,
                Y = 2,
                Dir = Cardinals.S
            };
            var area_coordinates = new List<int>() { 6, 6 };
            var commands = "MRMLMRMRM";
            rover.Move(commands, area_coordinates);
            var output = rover.X + " " + rover.Y + " " + rover.Dir;
            var expected = "2 1 N";
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void TestMethod4() //Sonuç Testi
        {
            Rover rover = new Rover()
            {
                X = 6,
                Y = 3,
                Dir = Cardinals.W
            };
            var area_coordinates = new List<int>() { 6, 6 };
            var commands = "MLMMMLM";
            rover.Move(commands, area_coordinates);
            var output = rover.X + " " + rover.Y + " " + rover.Dir;
            var expected = "6 0 E";
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void TestMethod5() // Komutlarýn M,R,L dýþýnda verilmesi halinde aracýn hareket etmemesi testi
        {
            Rover rover = new Rover()
            {
                X = 5,
                Y = 2,
                Dir = Cardinals.S
            };
            var area_coordinates = new List<int>() { 5, 5 };
            var commands = "A";
            rover.Move(commands, area_coordinates);
            var output = rover.X + " " + rover.Y + " " + rover.Dir;
            var expected = "5 2 S";
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod6() // Araç hareket ederken sýnýrlarýn dýþýna çýkarsa testi
        {
            Rover rover = new Rover()
            {
                X = 5,
                Y = 2,
                Dir = Cardinals.S
            };
            var area_coordinates = new List<int>() { 5, 5 };
            var commands = "MMM";
            rover.Move(commands, area_coordinates);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod7() //Araç alan sýnýrlarý dýþýna yerleþtirilmeye çalýþýrsa testi
        {
            Rover rover = new Rover()
            {
                X = 6,
                Y = 2,
                Dir = Cardinals.E
            };
            var area_coordinates = new List<int>() { 5, 5 };
            var commands = "LMLM";
            rover.Move(commands, area_coordinates);
        }
    }
}
