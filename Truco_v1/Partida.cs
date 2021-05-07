using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Truco_v1
{
    class Partida
    {
		private int pontosComputador;
		private int pontosJogador;


		public bool AcabouOJogo()
		{
			ConsoleColor aux = Console.ForegroundColor;
			if (this.pontosComputador > 10)
			{
				Console.WriteLine("=======================================");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("VOCÊ PERDEU O JOGO.");
				Console.ForegroundColor = aux;
				Console.WriteLine("Deseja jogar novamente? 1.sim 2.não");
				Console.WriteLine("=======================================");
				string num = Console.ReadLine();
				if (num == "1")
				{
					this.pontosComputador = 0;
					this.pontosJogador = 0;
					return false;
				}
				else if (num == "2")
				{
					Environment.Exit(0);
				}
				else
				{
					throw new Excecoes("Digite um número válido (1 ou 2)");
				}
				return true;
			}
			else if (this.pontosJogador > 10)
			{
				Console.WriteLine("=======================================");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("VOCÊ VENCEU O JOGO!!!");
				Console.ForegroundColor = aux;
				Console.WriteLine("Deseja jogar novamente? 1.sim 2.não");
				Console.WriteLine("=======================================");
				string num = Console.ReadLine();
				if (num == "1")
				{
					this.pontosJogador = 0;
					this.pontosComputador = 0;
					Console.Clear();
					return false;
				}
				else if (num == "2")
				{
					Environment.Exit(0);
				}
				else
				{
					throw new Excecoes("Digite um número válido (1 ou 2)");
				}
				return true;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("A partida continua");
				Console.ForegroundColor = aux;
				Console.WriteLine("=======================================");
				Thread.Sleep(2500);
				Console.Clear();
				return false;
			}
		}

		public int getpontosComputador()
		{
			return this.pontosComputador;
		}

		public int getpontosJogador()
		{
			return this.pontosJogador;
		}

		public void setpontosComputador(int pontosComputador)
		{
			this.pontosComputador += pontosComputador;
		}

		public void setpontosJogador(int pontosJogador)
		{
			this.pontosJogador += pontosJogador;
		}

	}

}
