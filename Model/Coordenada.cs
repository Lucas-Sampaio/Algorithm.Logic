using Algorithm.Logic.Exceptions;
using Algorithm.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Model
{

    public class Coordenada
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string _input;
        private readonly int _overflowPositivo =  2147483647;
        private readonly int _overflowNegativo = -2147483648;

        public Coordenada(string input)
        {
            X = 0;
            Y = 0;
            _input = input?.ToUpper();
        }

        public string ObterCoordenada()
        {
            try
            {
                if (!isValid()) throw new CoordenadaException("Valor de entrada Invalido");

                _= CancelarOperacoes();
                ConfigurarCoordenada();
            }
            catch (Exception ex)
            {
                X = 999;
                Y = 999;
            }
            return $"({X}, {Y})";
        }

        public void ConfigurarCoordenada()
        {
            var operacoes = ObterPartes(_input);
            foreach (var operacao in operacoes)
            {
                var sigla = operacao[0];
                var valor = ObterValorOperacao(operacao);


                switch (sigla)
                {
                    case 'N':
                        if (Y == _overflowPositivo) throw new CoordenadaException("Ocorreu um overflow");
                        Y += valor;
                        break;

                    case 'S':
                        if (Y == -_overflowNegativo) throw new CoordenadaException("Ocorreu um overflow");
                        Y -= valor;
                        break;

                    case 'L':
                        if (X == _overflowPositivo) throw new CoordenadaException("Ocorreu um overflow");
                        X += valor;
                        break;

                    case 'O':
                        if (X == -_overflowNegativo) throw new CoordenadaException("Ocorreu um overflow");
                        X -= valor;
                        break;
                }
            }

        }

        public bool isValid()
        {
            var valido = !string.IsNullOrWhiteSpace(_input); //verfica se é nulo
            valido = valido && !Regex.IsMatch(_input, @"^\d"); //verifica se começa com numero
            valido = valido && !Regex.IsMatch(_input, @"[^SNLOX0-9]"); //verifica se nao tem os caracteres aceitos
            valido = valido && !Regex.IsMatch(_input, @"[X]\d");  // verifica se tem numero dps do x
            valido = valido && Regex.IsMatch(_input, @"[A-Z]([1-9]|214748364[0-7])?[A-Z]"); //verifica se o numero ta entre 1 e int.MaxValue

            return valido;
        }

        /// <summary>
        /// Cancela Operações se tiver X
        /// </summary>
        public string CancelarOperacoes()
        {
            while (_input.Contains("X"))
            {
                var match = Regex.Match(_input, @"[SNLO]\d*?[X]");
                _input = _input.Replace(match.ToString(), "");
            }
            return _input;
        }

        private IEnumerable<string> ObterPartes(string input)
        {
            var matches = Regex.Matches(input, @"[SNLO]\d*");
            var partes = matches.Cast<Match>()
                                .Select(m => m.Value)
                                .ToArray();
            return partes;
        }

        private int ObterValorOperacao(string operacao)
        {
            var numero = operacao.ApenasNumeros();
            return numero.ToInt32(1);
        }

    }
}
