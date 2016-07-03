# Easyception

A library that provides a fluent API for managing exceptions with C# 6. (Must have C# 6 to use the API)

## Setup

To use this project you'll first need a couple of things:
  - Visual Studio 2015
  - C# 6

## How To Use

Using Easyception is easy. The below sections will dicuss how to utilize the Easyception API to manage exceptions in different ways.

##### How to throw

Throwing exceptions using Easyception is done using semantics that feel like an English sentence. The below example will show how to do this using the most basic version of the **Throw<T>** API to throw an InvalidOperationException.

If you are unfamilar with the ?. operator refer to this MSDN article on null-conditionals: https://msdn.microsoft.com/en-us/library/dn986595.aspx

It is absolutely **critical** that you use **?.** for performance reasons. Non-extension version of Now() will throw exceptions when you don't want them if you don't use **?.**

```
using Easyception;

public class Demo
{
  public void TestMethod(int val)
  {
    Throw<InvalidOperationException>.If.IsTrue(val < 0)?.Now();
  }
}
```

The above example will throw an **InvalidOperationException** if the provided int **val** is negative. There are various other ways to throw using Throw<T>.If. Explore intellisense to get a feeling for the various methods.

But wait! We have **special methods** depending on Throw<T>'s type T. Check out the example below that highlights special methods that are only available for certain types of T.

```
using Easyception;

public class Demo
{
  public void TestMethod(List<int> obj)
  {
    Throw<ArgumentNullException>.If.IsNull(obj)?.Now();
  }
}
```

The above example will throw an **ArgumentNullException** if the provided int **List<int>** is null. This **IsNull* method API is only available if T is ArgumentNullException in Throw<T>. Other exception types have methods like this also so check intellisense for them.

## Builds

Available on a Nuget Feed: https://www.myget.org/F/hellokitty/api/v2 [![hellokitty MyGet Build Status](https://www.myget.org/BuildSource/Badge/hellokitty?identifier=48dd3f2a-4278-4376-b211-65ca50a5db76)](https://www.myget.org/)

Offical Nuget: https://www.nuget.org/packages/Easyception/

##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/Easyception.svg?branch=master)](https://travis-ci.org/HelloKitty/Easyception) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/Easyception.svg?branch=dev)](https://travis-ci.org/HelloKitty/Easyception)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license.
