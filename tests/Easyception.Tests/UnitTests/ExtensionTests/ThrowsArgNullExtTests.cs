using Easyception;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyception.Tests
{
	[TestFixture]
	public class ThrowsArgNullExtTests
	{
		[Test]
		public static void Test_That_Null_IfChainer_Doesnt_Cause_NullRefEx()
		{
			//assert
			Assert.DoesNotThrow(() => (null as IIfSemanticChainer<ArgumentNullException>).IsNull(new object()));
		}

		[Test]
		public static void Test_That_Null_IfChainer_Doesnt_Throw_NullRefExOverload1()
		{
			//assert
			Assert.DoesNotThrow(() => (null as IIfSemanticChainer<ArgumentNullException>).IsNull(new object())?.Now(""));
		}

		[Test]
		public static void Test_That_Null_IfChainer_Doesnt_Throw_NullRefExOverload2()
		{
			//assert
			Assert.DoesNotThrow(() => (null as IIfSemanticChainer<ArgumentNullException>).IsNull(new object())?.Now("", ""));
		}

		[Test]
		public static void Test_That_ThrowsArgNull_Ext_IsNull_Throws_On_Null()
		{
			//arrange
			ICollection<int> testObj = null;

			//assert
			Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.If.IsNull(testObj)?.Now());
		}

		[Test]
		public static void Test_That_ThrowsArgNull_Ext_IsNull_Throws_On_NullOverload1()
		{
			//arrange
			ICollection<int> testObj = null;

			//assert
			Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.If.IsNull(testObj)?.Now(""));
		}

		[Test]
		public static void Test_That_ThrowsArgNull_Ext_IsNull_Throws_On_NullOverload2()
		{
			//arrange
			ICollection<int> testObj = null;

			//assert
			Assert.Throws<ArgumentNullException>(() => Throw<ArgumentNullException>.If.IsNull(testObj)?.Now("", ""));
		}

		//Testing that it doesn't throw on non-null

		[Test]
		public static void Test_That_ThrowsArgNull_Ext_IsNull_Doesnt_Throw_On_NonNull()
		{
			//arrange
			ICollection<int> testObj = new List<int>();

			//assert
			Assert.DoesNotThrow(() => Throw<ArgumentNullException>.If.IsNull(testObj));
		}

		[Test]
		public static void Test_That_ThrowsArgNull_Ext_IsNull_Doesnt_Throw_On_NonNullOverload1()
		{
			//arrange
			ICollection<int> testObj = new List<int>();

			//assert
			Assert.DoesNotThrow(() => Throw<ArgumentNullException>.If.IsNull(testObj)?.Now(""));
		}

		[Test]
		public static void Test_That_ThrowsArgNull_Ext_IsNull_Doesnt_Throw_On_NonNullOverload2()
		{
			//arrange
			ICollection<int> testObj = new List<int>();

			//assert
			Assert.DoesNotThrow(() => Throw<ArgumentNullException>.If.IsNull(testObj)?.Now());
		}

		[Test]
		public static void Test_That_Thrown_Exception_Contains_Provided_InformationOverload1()
		{
			//arrange
			ICollection<int> testObj = null;

			//act
			try
			{
				Throw<ArgumentNullException>.If.IsNull(testObj)?.Now(nameof(testObj));
			}
			catch(ArgumentNullException e)
			{
				//assert
				Assert.AreEqual(e.ParamName, nameof(testObj));
			}
		}

		[Test]
		public static void Test_That_Thrown_Exception_Contains_Provided_InformationOverload2()
		{
			//arrange
			ICollection<int> testObj = null;

			//act
			try
			{
				Throw<ArgumentNullException>.If.IsNull(testObj)?.Now(nameof(testObj), nameof(Test_That_Thrown_Exception_Contains_Provided_InformationOverload2));
			}
			catch (ArgumentNullException e)
			{
				//assert
				Assert.AreEqual(e.ParamName, nameof(testObj));
				Assert.True(e.Message.Contains(nameof(Test_That_Thrown_Exception_Contains_Provided_InformationOverload2)));
			}
		}
	}
}
