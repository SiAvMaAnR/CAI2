using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace CAI2.Models
{
    public class Logic
    {
        //public string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        public IsCorrect GetLexemes(ObservableCollection<Lexeme> lexemes, string code)
        {
            //code = code.Replace(" ", "");

            string localCode = code.TrimEnd();

            List<(Regex, string)> Reserve = new List<(Regex, string)>()
            {
                (new Regex(@"^int|^double|^float"),"Тип данных"),
                (new Regex(@"^="),"Оператор присваивания"),
                (new Regex(@"^\+"),"Оператор \"+\""),
                (new Regex(@"^\-"),"Оператор \"-\""),
                (new Regex(@"^\*"),"Оператор \"*\""),
                (new Regex(@"^\/"),"Оператор \"/\""),
                (new Regex(@"^\;"),"Оператор \";\""),
                (new Regex(@"^[a-zA-Z]\w*"),"Переменная"),
                (new Regex(@"^\d+\.\d*"),"Вещественное число"),
                (new Regex(@"^\d+"),"Целочисленное число")
            };

            int number = 0;
            int positionStart = 1;
            int positionEnd = 1;
            while (localCode.Length > 0)
            {
                Match search = null;
                localCode = localCode.TrimStart();
                foreach (var item in Reserve)
                {
                    if (item.Item1.IsMatch(localCode))
                    {
                        if (search == null || item.Item1.Match(localCode).Value.Length > search.Value.Length)
                        {
                            search = item.Item1.Match(localCode);
                            number = Reserve.IndexOf(item);
                            positionEnd = positionStart + search.Value.Length - 1;
                        }
                    }
                }
                if (search == null) throw new Exception($"Не знакомая лексема {localCode.Split(' ').First()}! ");

                lexemes.Add(new Lexeme()
                {
                    Name = search?.Value,
                    Type = Reserve[number].Item2,
                    Position = (positionStart, positionEnd),
                });
                localCode = localCode.Substring(search.Value.Length);
                positionStart = positionEnd + 1;
            }

            return IsCorrect.Correct;
        }
    }
}
