using System.Text.RegularExpressions;
using ConsoleApp.DependencyServices.Interface;
using Microsoft.Extensions.Logging;
// import Linq
using System.Linq;

namespace ConsoleApp.DependencyServices;

public partial class BasicMath : IMath {
    private int _holder;
    private readonly List<int> _history = new();
    private List<(int, string)> _formula = new();

    private ILogger<MyDateTime> Logger { get; }

    public BasicMath(ILogger<MyDateTime> logger) {
        _holder = 0;
        Logger = logger;
    }

    public void Plus(int a) {
        _history.Add(_holder += a);
    }

    public void Minus(int a) {
        _history.Add(_holder -= a);
    }

    public void Multi(int a) {
        _history.Add(_holder *= a);
    }

    public void Divide(int a) {
        _history.Add(_holder /= a);
    }

    public int Current() {
        return _holder;
    }

    public int Latest() {
        return _history.Last();
    }

    /// <summary>
    /// 四則演算を開始
    /// 標準入力から計算式を受け取り、四則演算を行う
    /// </summary>
    public void Calculate() {
        // write to console, add and sub and multi and div
        Console.WriteLine("input formula:");
        TryParseCalculateMethod();
        // formulaの演算子パラメータを使ってソートを行う
        // 文字が [*, /]のどちらかの場合の優先度を高くする
        _formula = _formula.OrderBy(x => x.Item2 is "*" or "/" ? 0 : 1).ToList();

        // _formulaの演算子パラメータを使って計算を行う
        _holder = _formula.Aggregate((result, current) => {
            return current.Item2 switch {
                "+" => (result.Item1 + current.Item1, current.Item2),
                "-" => (result.Item1 - current.Item1, current.Item2),
                "*" => (result.Item1 * current.Item1, current.Item2),
                "/" => (result.Item1 / current.Item1, current.Item2),
                _ => (result.Item1, "")
            };
        }).Item1;
    }

    /// <summary>
    /// 入力をで1文字ずつ解析して、計算式用データを生成する
    /// </summary>
    public void TryParseCalculateMethod() {
        var input = Console.ReadLine();
        if (input is null) return;
        input = MyValid(input);
        // 入力文字列を1文字ずつ解析する
        var charArr = input.ToCharArray();
        var numberStr = "";
        var operand = "";
        foreach (var c in charArr) {
            if (int.TryParse(c.ToString(), out var num)) {
                // 数字の場合は桁数をスタックに積む
                numberStr += c;
            }
            else {
                // 数値以外の場合、桁数を確定する
                int.TryParse(numberStr, out var number);
                numberStr = "";
                // 数値と演算子をスタックに積む
                _formula.Add((number, operand));
                operand = c.ToString();
            }
        }

        // 数値以外の場合、桁数を確定する
        int.TryParse(numberStr, out var last);
        // 数値と演算子をスタックに積む
        _formula.Add((last, operand));
    }

    [GeneratedRegex("^[0-9\\+\\-\\*\\/]+$")]
    private static partial Regex MyRegex();

    private static string MyValid(string source) {
        // inputからスペース文字を除去
        source = source.Replace(" ", "");
        // 入力文字列が、以下の文字のみで構成されていることを正規表現でチェックする
        // 0-9, +, -, *, /
        if (!MyRegex().IsMatch(source)) {
            throw new ArgumentException("Invalid argument");
        }

        return source;
    }
}