using System;

namespace Easyception
{
	/// <summary>
	/// Implements implement factory instance creation logic for <typeparamref name="TExceptionType"/>
	/// exceptions.
	/// </summary>
	/// <typeparam name="TExceptionType">The <see cref="Type"/> of exception to create.</typeparam>
	internal interface IExceptionInstanceFactory<TExceptionType>
		where TExceptionType : Exception, new()
	{
		/// <summary>
		/// Creates a new instance of <see cref="Type"/> <typeparamref name="TExceptionType"/>
		/// using the <see cref="Type"/>'s parameterless constructor.
		/// </summary>
		/// <returns>A new non-null instance of <typeparamref name="TExceptionType"/>.</returns>
		TExceptionType Create();
	}
}
