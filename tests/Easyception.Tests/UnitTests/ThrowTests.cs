using NUnit.Framework;
using System;

namespace Easyception.Tests
{
	[TestFixture]
	public static class ThrowTests
	{
		[Test]
		public static void Test_That_Static_Throw_Ctor_Doesnt_Throw()
		{
			//assert
			Assert.DoesNotThrow(() => { var o = Throw<Exception>.If; });
		}

		[Test]
		public static void Test_That_Exception_Is_Thrown_When_If_Condition_Is_True()
		{
			//assert
			Assert.Throws<Exception>(() => Throw<Exception>.If.IsTrue(true));
		}

		[Test]
		public static void Test_That_Exception_Isnt_Thrown_When_If_Condition_Is_False()
		{
			//assert
			Assert.DoesNotThrow(() => Throw<Exception>.If.IsTrue(false));
		}

		[Test]
		[TestCase(typeof(Exception))]
		[TestCase(typeof(ArgumentException))]
		[TestCase(typeof(InvalidCastException))]
		[TestCase(typeof(InvalidOperationException))]
		[TestCase(typeof(EntryPointNotFoundException))]
		[TestCase(typeof(TestException))]
		public static void Test_That_Exception_Thrown_Is_Correct_Type(Type exceptionType)
		{
			//Assert it's an exception type
			Assert.IsTrue(typeof(Exception).IsAssignableFrom(exceptionType));

			//assert
			Assert.Throws(exceptionType, () => (typeof(Throw<>).MakeGenericType(exceptionType).GetProperty("If").GetValue(null, null) as IIfSemanticChainer).IsTrue(true));
		}

		private class TestException : Exception
		{

		}
	}
}
