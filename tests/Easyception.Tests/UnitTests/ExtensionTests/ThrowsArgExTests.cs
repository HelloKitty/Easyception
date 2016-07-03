using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyception.Tests
{
	[TestFixture]
	public static class ThrowsArgExTests
	{
		//true tests

		[Test]
		public static void Test_That_ThrowsArgx_Ext_IsTrue_Throws_On_True()
		{
			//assert
			Assert.Throws<ArgumentException> (() => Throw<ArgumentException>.If.IsTrue(true)?.Now(""));
		}

		[Test]
		public static void Test_That_ThrowsArgx_Ext_IsTrue_Throws_On_TrueOverload1()
		{
			//assert
			Assert.Throws<ArgumentException>(() => Throw<ArgumentException>.If.IsTrue(true)?.Now("", ""));
		}

		//false tests

		[Test]
		public static void Test_That_ThrowsArgx_Ext_IsTrue_Doesnt_Throw_On_False()
		{
			//assert
			Assert.DoesNotThrow(() => Throw<ArgumentException>.If.IsTrue(false)?.Now(""));
		}

		[Test]
		public static void Test_That_ThrowsArgx_Ext_IsTrue_Doesnt_Throw_On_FalseOverload1()
		{
			//assert
			Assert.DoesNotThrow(() => Throw<ArgumentException>.If.IsTrue(false)?.Now("", ""));
		}

		[Test]
		public static void Test_That_Thrown_Exception_Contains_Provided_Information()
		{
			//act
			try
			{
				Throw<ArgumentException>.If.IsTrue(true)?.Now("hiya");
			}
			catch (ArgumentException e)
			{
				//assert
				Assert.True(e.Message.Contains("hiya"));
			}
		}

		[Test]
		public static void Test_That_Thrown_Exception_Contains_Provided_InformationOverload1()
		{
			//act
			try
			{
				Throw<ArgumentException>.If.IsTrue(true)?.Now("hiya", "paramName");
			}
			catch (ArgumentException e)
			{
				//assert
				Assert.True(e.Message.Contains("hiya"));
				Assert.AreEqual("paramName", e.ParamName);
			}
		}
	}
}
