using ChessExample;
using System;

namespace CheckBoardPosition.Tests;

// для позиции x и y, тест на позиции от 1 до 8
public class UnitTest1
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void Test1(byte x)
    {
        var pos = new CheckerBoardPosition(x, 1);
        Assert.Equal(x, pos.X);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void Test2(byte y)
    {
        var pos = new CheckerBoardPosition(1, y);
        Assert.Equal(y, pos.Y);
    }
}

// тест если у нас позиции вышли за 1 и за 8
public class UnitTest2
{
    [Theory]
    [InlineData(0)]
    [InlineData(9)]
    public void Test3(byte x)
    {
        Assert.Throws<ArgumentOutOfRangeException> (() => new CheckerBoardPosition(x, 1));
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(9)]
    public void Test4(byte y)
    {
        Assert.Throws<ArgumentOutOfRangeException> (() => new CheckerBoardPosition(1, y));
    }
}


// Заметки для тестов
// 1. Доска имеет от 1 до 8 позиций.
// 2. Нужно узнать, может ли доска быть меньше 1(то есть 0) или больше 8(то есть 9)
