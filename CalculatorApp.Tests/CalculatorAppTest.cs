using System;
using NUnit.Framework;
using CalculatorApp.Core;

namespace CalculatorApp.Tests
{
    public class CalculatorAppTest
    {

        // Passing tests for addnumbers()
        [Test]
        // Normal Additions
        [TestCase("7", 3, 4)]
        [TestCase("55", 30, 25)]
        [TestCase("24", 45, -21)]
        // Edge cases [-1, 0, 1, maxvalue, minvalue]
        // TODO: cant put toString()
        // cases of 1
        [TestCase("6", 1, 5)]
        [TestCase("4", 3, 1)]
        [TestCase("2", 1, 1)]
        [TestCase("1", 1, 0)]
        [TestCase("0", 1, -1)]
        // cases of -1
        [TestCase("-4", -1, -3)]
        [TestCase("77", 78, -1)]
        [TestCase("-2", -1, -1)]
        [TestCase("0", -1, 1)]
        [TestCase("-1", -1, 0)]
        // cases of 0
        [TestCase("4", 0, 4)]
        [TestCase("-2", -2, 0)]
        [TestCase("0", 0, 0)]
        [TestCase("1", 0, 1)]
        [TestCase("-1", 0, -1)]
        public void testPassingAddnumbers(string expected, int i1, int i2)
        {

            Assert.That(expected, Is.EqualTo(CalculatorAppCore.addnumbers(i1, i2)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // cases of 1
            Assert.That(((Int64)Int32.MaxValue + (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(1, Int32.MaxValue)));        // with maxvalue
            Assert.That(((Int64)Int32.MinValue + (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(1, Int32.MinValue)));        // with minvalue

            // -1
            Assert.That(((Int64)Int32.MaxValue + -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(-1, Int32.MaxValue)));      // with maxvalue
            Assert.That(((Int64)Int32.MinValue + -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(-1, Int32.MinValue)));      // with minvalue

            // 0
            Assert.That(Int32.MaxValue.ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(0, Int32.MaxValue)));                            // with maxvalue
            Assert.That(Int32.MinValue.ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(0, Int32.MinValue)));                            // with minvalue

            // maxvalue 
            Assert.That(((Int64)Int32.MaxValue + (Int64)3).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, 3)));                                // On left
            Assert.That(((Int64)Int32.MaxValue + (Int64)45).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(45, Int32.MaxValue)));                              // On right
            Assert.That(((Int64)Int32.MaxValue + (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, Int32.MaxValue)));      // On both
            Assert.That(((Int64)Int32.MaxValue + -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, -1)));                              // with -1
            Assert.That(((Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, 0)));                                           // with 0
            Assert.That(((Int64)Int32.MaxValue + (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, 1)));                                // with 1
            Assert.That(((Int64)Int32.MaxValue + (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, Int32.MinValue)));      // with minvalue

            // minvalue
            Assert.That(((Int64)Int32.MinValue + -(Int64)3).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, -3)));                              // On left
            Assert.That(((Int64)Int32.MinValue + -(Int64)8).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(-8, Int32.MinValue)));                              // On right
            Assert.That(((Int64)Int32.MinValue + (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, Int32.MinValue)));      // On both
            Assert.That(((Int64)Int32.MinValue + (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, 1)));                                // with 1
            Assert.That(((Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, 0)));                                           // with 0
            Assert.That(((Int64)Int32.MinValue + -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, -1)));                              // with -1
            Assert.That(((Int64)Int32.MinValue + (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, Int32.MaxValue)));     // with maxvalue

        }

        // Failing tests for addnumbers()
        [Test]
        public void testFailingAddnumbers()
        {
            // Normal additions
            Assert.That("865", Is.Not.EqualTo(CalculatorAppCore.addnumbers(43, 43)));
            Assert.That("55255", Is.Not.EqualTo(CalculatorAppCore.addnumbers(5230, 25)));
            Assert.That("5022", Is.Not.EqualTo(CalculatorAppCore.addnumbers(533, -31)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // 1
            Assert.That("326", Is.Not.EqualTo(CalculatorAppCore.addnumbers(1, 5)));                     // On left
            Assert.That("54", Is.Not.EqualTo(CalculatorAppCore.addnumbers(543, 1)));                    // On right
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.addnumbers(1, 1)));                   // On both
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.addnumbers(1, 0)));                   // with 0
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.addnumbers(1, -1)));                  // with -1
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.addnumbers(1, Int32.MaxValue)));      // with maxvalue
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.addnumbers(1, Int32.MinValue)));      // with minvalue
                

            // -1
            Assert.That("-34", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-1, -3)));                   // On left
            Assert.That("-3", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-532, -1)));                  // On right
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-1, -1)));                    // On both
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-1, 1)));                     // with 1
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-1, 0)));                     // With 0
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-1, Int32.MaxValue)));        // with maxvalue
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.addnumbers(-1, Int32.MinValue)));        // with minvalue

            // 0
            Assert.That("432", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, 321)));                   // On left
            Assert.That("32", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, 4242)));                   // On right
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, 12121)));                 // on both
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, 1)));                     // with 1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, -1)));                    // with -1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, Int32.MaxValue)));        // with maxvalue
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.addnumbers(0, Int32.MinValue)));        // with minvalue


            // maxvalue
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, 3)));                // On left
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(3, Int32.MaxValue)));                // On right
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, Int32.MaxValue)));   // On both
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, 1)));                // with 1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, 0)));                // with 0
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, -1)));               // with -1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MaxValue, Int32.MinValue)));   // with minvalue

            // minvalue
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, -3)));               // On left
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(3, Int32.MinValue)));                // On right
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, Int32.MinValue)));   // On both
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, 1)));                // with 1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, 0)));                // with 0
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, -1)));               // with -1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.addnumbers(Int32.MinValue, Int32.MaxValue)));   // with maxvalue


        }

        // Passing tests for subtractnumbers()
        [Test]
        public void testPassingSubtractnumbers()
        {
            // Normal subtractions
            Assert.That("2", Is.EqualTo(CalculatorAppCore.subtractnumbers(4, 2)));
            Assert.That("55", Is.EqualTo(CalculatorAppCore.subtractnumbers(30, -25)));
            Assert.That("260", Is.EqualTo(CalculatorAppCore.subtractnumbers(265, 5)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // cases of 1
            Assert.That("-4", Is.EqualTo(CalculatorAppCore.subtractnumbers(1, 5)));                                                               // On left
            Assert.That("2", Is.EqualTo(CalculatorAppCore.subtractnumbers(3, 1)));                                                               // On right
            Assert.That("0", Is.EqualTo(CalculatorAppCore.subtractnumbers(1, 1)));                                                               // On both
            Assert.That("1", Is.EqualTo(CalculatorAppCore.subtractnumbers(1, 0)));                                                               // with 0
            Assert.That("2", Is.EqualTo(CalculatorAppCore.subtractnumbers(1, -1)));                                                              // with -1
            Assert.That(((Int64)1 - (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(1, Int32.MaxValue)));        // with maxvalue
            Assert.That(((Int64)1 - (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(1, Int32.MinValue)));        // with minvalue

            // -1
            Assert.That("2", Is.EqualTo(CalculatorAppCore.subtractnumbers(-1, -3)));                                                            // On left
            Assert.That("79", Is.EqualTo(CalculatorAppCore.subtractnumbers(78, -1)));                                                            // On right
            Assert.That("0", Is.EqualTo(CalculatorAppCore.subtractnumbers(-1, -1)));                                                            // On both
            Assert.That("-2", Is.EqualTo(CalculatorAppCore.subtractnumbers(-1, 1)));                                                              // with 1
            Assert.That("-1", Is.EqualTo(CalculatorAppCore.subtractnumbers(-1, 0)));                                                             // with 0
            Assert.That((-(Int64)1 - (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(-1, Int32.MaxValue)));      // with maxvalue
            Assert.That((-(Int64)1 - (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(-1, Int32.MinValue)));      // with minvalue

            // 0
            Assert.That("-4", Is.EqualTo(CalculatorAppCore.subtractnumbers(0, 4)));                                                               // On left
            Assert.That("-2", Is.EqualTo(CalculatorAppCore.subtractnumbers(-2, 0)));                                                             // On right
            Assert.That("0", Is.EqualTo(CalculatorAppCore.subtractnumbers(0, 0)));                                                               // On both
            Assert.That("-1", Is.EqualTo(CalculatorAppCore.subtractnumbers(0, 1)));                                                               // with 1
            Assert.That("1", Is.EqualTo(CalculatorAppCore.subtractnumbers(0, -1)));                                                             // with -1
            Assert.That(((Int64)Int32.MaxValue * -1).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(0, Int32.MaxValue)));                            // with maxvalue
            Assert.That(((Int64)Int32.MinValue * -1).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(0, Int32.MinValue)));                            // with minvalue

            // maxvalue 
            Assert.That(((Int64)Int32.MaxValue - (Int64)3).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, 3)));                                // On left
            Assert.That((((Int64)Int32.MaxValue * -1) + (Int64)45).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(45, Int32.MaxValue)));                              // On right
            Assert.That(((Int64)Int32.MaxValue - (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, Int32.MaxValue)));      // On both
            Assert.That(((Int64)Int32.MaxValue - -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, -1)));                              // with -1
            Assert.That(((Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, 0)));                                           // with 0
            Assert.That(((Int64)Int32.MaxValue - (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, 1)));                                // with 1
            Assert.That(((Int64)Int32.MaxValue - (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, Int32.MinValue)));      // with minvalue

            // minvalue
            Assert.That(((Int64)Int32.MinValue - -(Int64)3).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, -3)));                              // On left
            Assert.That((-(Int64)8 + ((Int64)Int32.MinValue * -1)).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(-8, Int32.MinValue)));                              // On right
            Assert.That(((Int64)Int32.MinValue - (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, Int32.MinValue)));      // On both
            Assert.That(((Int64)Int32.MinValue - (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, 1)));                                // with 1
            Assert.That(((Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, 0)));                                           // with 0
            Assert.That(((Int64)Int32.MinValue - -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, -1)));                              // with -1
            Assert.That(((Int64)Int32.MinValue - (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, Int32.MaxValue)));     // with maxvalue

        }

        // Failing tests for subtractnumbers()
        [Test]
        public void testFailingSubtractnumbers()
        {
            // Normal additions
            Assert.That("3329", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(43, 4)));
            Assert.That("52305", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(5230, 25)));
            Assert.That("-2", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(33, -35)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // 1
            Assert.That("326", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(1, 5)));                     // On left
            Assert.That("54", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(543, 1)));                    // On right
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(1, 1)));                   // On both
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(1, 0)));                   // with 0
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(1, -1)));                  // with -1
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(1, Int32.MaxValue)));      // with maxvalue
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(1, Int32.MinValue)));      // with minvalue


            // -1
            Assert.That("-34", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-1, -3)));                   // On left
            Assert.That("-3", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-532, -1)));                  // On right
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-1, -1)));                    // On both
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-1, 1)));                     // with 1
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-1, 0)));                     // With 0
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-1, Int32.MaxValue)));        // with maxvalue
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(-1, Int32.MinValue)));        // with minvalue

            // 0
            Assert.That("432", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, 321)));                   // On left
            Assert.That("32", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, 4242)));                   // On right
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, 12121)));                 // on both
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, 1)));                     // with 1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, -1)));                    // with -1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, Int32.MaxValue)));        // with maxvalue
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(0, Int32.MinValue)));        // with minvalue


            // maxvalue
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, 3)));                // On left
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(3, Int32.MaxValue)));                // On right
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, Int32.MaxValue)));   // On both
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, 1)));                // with 1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, 0)));                // with 0
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, -1)));               // with -1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MaxValue, Int32.MinValue)));   // with minvalue

            // minvalue
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, -3)));               // On left
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(3, Int32.MinValue)));                // On right
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, Int32.MinValue)));   // On both
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, 1)));                // with 1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, 0)));                // with 0
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, -1)));               // with -1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.subtractnumbers(Int32.MinValue, Int32.MaxValue)));   // with maxvalue

        }

        // Passing tests for multiplynumbers()
        [Test]
        public void testPassingMultiplynumbers()
        {
            // Normal subtractions
            Assert.That("12", Is.EqualTo(CalculatorAppCore.multiplynumbers(4, 3)));
            Assert.That("-75", Is.EqualTo(CalculatorAppCore.multiplynumbers(3, -25)));
            Assert.That("130", Is.EqualTo(CalculatorAppCore.multiplynumbers(65, 2)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // cases of 1
            Assert.That("5", Is.EqualTo(CalculatorAppCore.multiplynumbers(1, 5)));                                                               // On left
            Assert.That("3", Is.EqualTo(CalculatorAppCore.multiplynumbers(3, 1)));                                                               // On right
            Assert.That("1", Is.EqualTo(CalculatorAppCore.multiplynumbers(1, 1)));                                                               // On both
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(1, 0)));                                                               // with 0
            Assert.That("-1", Is.EqualTo(CalculatorAppCore.multiplynumbers(1, -1)));                                                              // with -1
            Assert.That(((Int64)Int32.MaxValue * (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(1, Int32.MaxValue)));        // with maxvalue
            Assert.That(((Int64)Int32.MinValue * (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(1, Int32.MinValue)));        // with minvalue

            // -1
            Assert.That("3", Is.EqualTo(CalculatorAppCore.multiplynumbers(-1, -3)));                                                            // On left
            Assert.That("-78", Is.EqualTo(CalculatorAppCore.multiplynumbers(78, -1)));                                                            // On right
            Assert.That("1", Is.EqualTo(CalculatorAppCore.multiplynumbers(-1, -1)));                                                            // On both
            Assert.That("-1", Is.EqualTo(CalculatorAppCore.multiplynumbers(-1, 1)));                                                              // with 1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(-1, 0)));                                                             // with 0
            Assert.That(((Int64)Int32.MaxValue * -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(-1, Int32.MaxValue)));      // with maxvalue
            Assert.That(((Int64)Int32.MinValue * -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(-1, Int32.MinValue)));      // with minvalue

            // 0
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(0, 4)));                                                               // On left
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(-2, 0)));                                                             // On right
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(0, 0)));                                                               // On both
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(0, 1)));                                                               // with 1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(0, -1)));                                                             // with -1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(0, Int32.MaxValue)));                                                 // with maxvalue
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(0, Int32.MinValue)));                                                 // with minvalue

            // maxvalue 
            Assert.That(((Int64)Int32.MaxValue * (Int64)3).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, 3)));                                // On left
            Assert.That(((Int64)Int32.MaxValue * (Int64)45).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(45, Int32.MaxValue)));                              // On right
            Assert.That(((Int64)Int32.MaxValue * (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, Int32.MaxValue)));      // On both
            Assert.That(((Int64)Int32.MaxValue * -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, -1)));                              // with -1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, 0)));                                                                         // with 0
            Assert.That(((Int64)Int32.MaxValue * (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, 1)));                                // with 1
            Assert.That(((Int64)Int32.MaxValue * (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, Int32.MinValue)));      // with minvalue

            // minvalue
            Assert.That(((Int64)Int32.MinValue * -(Int64)3).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, -3)));                              // On left
            Assert.That(((Int64)Int32.MinValue * -(Int64)8).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(-8, Int32.MinValue)));                              // On right
            Assert.That(((Int64)Int32.MinValue * (Int64)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, Int32.MinValue)));      // On both
            Assert.That(((Int64)Int32.MinValue * (Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, 1)));                                // with 1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, 0)));                                           // with 0
            Assert.That(((Int64)Int32.MinValue * -(Int64)1).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, -1)));                              // with -1
            Assert.That(((Int64)Int32.MinValue * (Int64)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, Int32.MaxValue)));     // with maxvalue

        }

        // Failing tests for multiplynumbers()
        [Test]
        public void testFailingMultiplynumbers()
        {
            // Normal additions
            Assert.That("75", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(43, 4)));
            Assert.That("5", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(5230, 25)));
            Assert.That("-2", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(33, -35)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // 1
            Assert.That("326", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(1, 5)));                     // On left
            Assert.That("54", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(543, 1)));                    // On right
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(1, 1)));                   // On both
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(1, 0)));                   // with 0
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(1, -1)));                  // with -1
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(1, Int32.MaxValue)));      // with maxvalue
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(1, Int32.MinValue)));      // with minvalue


            // -1
            Assert.That("-34", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-1, -3)));                   // On left
            Assert.That("-3", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-532, -1)));                  // On right
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-1, -1)));                    // On both
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-1, 1)));                     // with 1
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-1, 0)));                     // With 0
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-1, Int32.MaxValue)));        // with maxvalue
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(-1, Int32.MinValue)));        // with minvalue

            // 0
            Assert.That("432", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, 321)));                   // On left
            Assert.That("32", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, 4242)));                   // On right
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, 12121)));                 // on both
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, 1)));                     // with 1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, -1)));                    // with -1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, Int32.MaxValue)));        // with maxvalue
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(0, Int32.MinValue)));        // with minvalue


            // maxvalue
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, 3)));                // On left
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(3, Int32.MaxValue)));                // On right
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, Int32.MaxValue)));   // On both
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, 1)));                // with 1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, 0)));                // with 0
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, -1)));               // with -1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MaxValue, Int32.MinValue)));   // with minvalue

            // minvalue
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, -3)));               // On left
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(3, Int32.MinValue)));                // On right
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, Int32.MinValue)));   // On both
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, 1)));                // with 1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, 0)));                // with 0
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, -1)));               // with -1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.multiplynumbers(Int32.MinValue, Int32.MaxValue)));   // with maxvalue

        }

        // Passing tests for dividenumbers()
        [Test]
        public void testPassingDividenumbers()
        {
            // Normal subtractions
            Assert.That("2", Is.EqualTo(CalculatorAppCore.dividenumbers(4, 2)));
            Assert.That("2,5", Is.EqualTo(CalculatorAppCore.dividenumbers(10, 4)));
            Assert.That("13", Is.EqualTo(CalculatorAppCore.dividenumbers(65, 5)));

            // Divide by zero
            Assert.Throws<DivideByZeroException>(() => CalculatorAppCore.dividenumbers(4, 0));
             
            /*try
            {
                Assert.That("4", Is.EqualTo(CalculatorAppCore.dividenumbers(4, 0)));
                Assert.That(true, Is.EqualTo(false));
            }
            catch (DivideByZeroException){}*/
             
             

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // cases of 1
            Assert.That("0,2", Is.EqualTo(CalculatorAppCore.dividenumbers(1, 5)));                                                               // On left
            Assert.That("3", Is.EqualTo(CalculatorAppCore.dividenumbers(3, 1)));                                                               // On right
            Assert.That("1", Is.EqualTo(CalculatorAppCore.dividenumbers(1, 1)));                                                               // On both
            Assert.That("-1", Is.EqualTo(CalculatorAppCore.dividenumbers(1, -1)));                                                              // with -1
            Assert.That(((float)1 / (float)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(1, Int32.MaxValue)));        // with maxvalue
            Assert.That(((float)1 / (float)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(1, Int32.MinValue)));        // with minvalue

            // -1
            Assert.That("0,25", Is.EqualTo(CalculatorAppCore.dividenumbers(-1, -4)));                                                            // On left
            Assert.That("-78", Is.EqualTo(CalculatorAppCore.dividenumbers(78, -1)));                                                            // On right
            Assert.That("1", Is.EqualTo(CalculatorAppCore.dividenumbers(-1, -1)));                                                            // On both
            Assert.That("-1", Is.EqualTo(CalculatorAppCore.dividenumbers(-1, 1)));                                                              // with 1
            Assert.That((-(float)1 / (float)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(-1, Int32.MaxValue)));      // with maxvalue
            Assert.That((-(float)1 / (float)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(-1, Int32.MinValue)));      // with minvalue

            // 0
            Assert.That("0", Is.EqualTo(CalculatorAppCore.dividenumbers(0, 4)));                                                               // On left
            Assert.That("0", Is.EqualTo(CalculatorAppCore.dividenumbers(0, 1)));                                                               // with 1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.dividenumbers(0, -1)));                                                             // with -1
            Assert.That("0", Is.EqualTo(CalculatorAppCore.dividenumbers(0, Int32.MaxValue)));                            // with maxvalue
            Assert.That("0", Is.EqualTo(CalculatorAppCore.dividenumbers(0, Int32.MinValue)));                            // with minvalue

            // maxvalue 
            Assert.That(((float)Int32.MaxValue / (float)3).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, 3)));                                // On left
            Assert.That(((float)45 / (float)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(45, Int32.MaxValue)));                              // On right
            Assert.That(((float)Int32.MaxValue / (float)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, Int32.MaxValue)));      // On both
            Assert.That(((float)Int32.MaxValue / -(float)1).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, -1)));                              // with -1
            Assert.That(((float)Int32.MaxValue / (float)1).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, 1)));                                // with 1
            Assert.That(((float)Int32.MaxValue / (float)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, Int32.MinValue)));      // with minvalue

            // minvalue
            Assert.That(((float)Int32.MinValue / -(float)3).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, -3)));                              // On left
            Assert.That((-(float)8 / (float)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(-8, Int32.MinValue)));                              // On right
            Assert.That(((float)Int32.MinValue / (float)Int32.MinValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, Int32.MinValue)));      // On both
            Assert.That(((float)Int32.MinValue / (float)1).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, 1)));                                // with 1
            Assert.That(((float)Int32.MinValue / -(float)1).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, -1)));                              // with -1
            Assert.That(((float)Int32.MinValue / (float)Int32.MaxValue).ToString(), Is.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, Int32.MaxValue)));     // with maxvalue

        }

        // Failing tests for dividenumbers()
        [Test]
        public void testFailingDividenumbers()
        {
            // Normal additions
            Assert.That("75", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(43, 4)));
            Assert.That("25", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(5230, 25)));
            Assert.That("-2", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(33, -35)));

            // Edge cases [-1, 0, 1, maxvalue, minvalue]
            // 1
            Assert.That("326", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(1, 5)));                     // On left
            Assert.That("54", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(543, 1)));                    // On right
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(1, 1)));                   // On both
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(1, -1)));                  // with -1
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(1, Int32.MaxValue)));      // with maxvalue
            Assert.That("32343", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(1, Int32.MinValue)));      // with minvalue


            // -1
            Assert.That("-34", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(-1, -3)));                   // On left
            Assert.That("-3", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(-532, -1)));                  // On right
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(-1, -1)));                    // On both
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(-1, 1)));                     // with 1
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(-1, Int32.MaxValue)));        // with maxvalue
            Assert.That("52", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(-1, Int32.MinValue)));        // with minvalue

            // 0
            Assert.That("432", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, 321)));                   // On left
            Assert.That("32", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, 4242)));                   // On right
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, 12121)));                 // on both
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, 1)));                     // with 1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, -1)));                    // with -1
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, Int32.MaxValue)));        // with maxvalue
            Assert.That("551", Is.Not.EqualTo(CalculatorAppCore.dividenumbers(0, Int32.MinValue)));        // with minvalue


            // maxvalue
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, 3)));                // On left
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(3, Int32.MaxValue)));                // On right
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, Int32.MaxValue)));   // On both
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, 1)));                // with 1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, -1)));               // with -1
            Assert.That(Int32.MinValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MaxValue, Int32.MinValue)));   // with minvalue

            // minvalue
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, -3)));               // On left
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(3, Int32.MinValue)));                // On right
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, Int32.MinValue)));   // On both
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, 1)));                // with 1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, -1)));               // with -1
            Assert.That(Int32.MaxValue.ToString(), Is.Not.EqualTo(CalculatorAppCore.dividenumbers(Int32.MinValue, Int32.MaxValue)));   // with maxvalue


        }
    }

}