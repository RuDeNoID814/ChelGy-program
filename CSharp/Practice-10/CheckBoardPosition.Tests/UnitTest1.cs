using ChessExample;
using System;

namespace CheckBoardPosition.Tests;

// для позиции x и y, тест на позиции от 1 до 8
public class NumberBoardTests
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
public class OutsideNumberBoardTests
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


public class XLetterTests
{
    [Theory]
    [InlineData(1,'A')]
    [InlineData(8,'H')]
    public void XLetter_X1_ReturnA(byte x, char symbol)
    {
        var pos = new CheckerBoardPosition(x, 1);
        Assert.Equal(symbol, pos.XLetter);
    }
}

public class VerificationPositionTests
{
    [Fact]
    public void Position_A1_Verification()
    {
        var pos = new CheckerBoardPosition(1, 1).ToString();
        Assert.Equal("A1", pos);
    }
}


public class ParseCheckTests
{
    // проверка что parse возвращает позицию из валидной строки
    [Fact]
    public void Parse_Check_Position()
    {
        var pos = CheckerBoardPosition.Parse("E4", null);
        Assert.Equal("E4", pos.ToString());
    }
    
    // проверка что parse бросает formatexception на невалидной строке
    [Theory]
    [InlineData("Z9")]
    [InlineData(null)]
    public void Parse_InvalidCheck_Position(string s)
    {
        Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(s, null));
    }
}


public class TryParseCheckTests
{
    [Fact]
    public void TryParse_Valid_Position()
    {
        var result = CheckerBoardPosition.TryParse("A1", null, out var pos);
        Assert.True(result);
    }

    [Fact]
    public void TryParse_InvalidCheck_Position()
    {
        var result = CheckerBoardPosition.TryParse("Z9", null, out var pos);
        Assert.False(result);
    }
}

// Заметки для тестов
// 1. Доска имеет от 1 до 8 позиций.
// 2. Нужно узнать, может ли доска быть меньше 1(то есть 0) или больше 8(то есть 9)
// 3. Проверка XLetter(ASCII), что он выдает символ от A(1(64+1)) до H(8(64+8))
// 4. Проверка, что ToString склеивает правильно
// 5. Проверка Parse
// 6. проверка TryParse