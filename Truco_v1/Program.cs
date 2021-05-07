using System;
using System.Threading;

namespace Truco_v1
{
	class Program
	{
		public static void Main(String[] args)
		{
			int numCard = 0, pesoJogador = 0, pesoComputador = 0;
			int ganhouAMao = 0;
			int maoComputador = 0, maoJogador = 0;
			bool acabouOJogo = false, jogadorGanhou = false, acabouARodada = false;
			bool jaJogou = false;
			ConsoleColor aux = Console.ForegroundColor;

			Partida pontos = new Partida();
			Controle control = new Controle();

			while (!acabouOJogo)
			{
				try
				{
					control.Baralho();  //distribui as cartas aleatórias
					jogadorGanhou = false;//reseta
					acabouARodada = false;
					int countMao = 0;

					int[] jaJogouEssaCarta = new int[3] { 0, 0, 0 };
					int[] comuputadorjaJogouEssa = new int[3] { 0, 0, 0 };

					while (!acabouARodada)
					{
						numCard = control.PegarCarta(); //pergunta qual carta o jogador deseja jogar
						jaJogou = control.JaJogou(numCard, jaJogouEssaCarta); //confere se já jogou esssa carta
						while (jaJogou)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("ERRO => Você já jogou essa carta, escolha outra...");
							Console.ForegroundColor = aux;
							numCard = control.PegarCarta();
							jaJogou = control.JaJogou(numCard, jaJogouEssaCarta);
						}
						pesoJogador = control.Jogar(numCard); //joga a carta que o jogador pediu e retorna o peso da carta
						Thread.Sleep(1500);
						pesoComputador = control.ComputadorJoga(comuputadorjaJogouEssa); //joga uma carta aleatoria do computador e retorna o peso da carta
						Thread.Sleep(1500);
						ganhouAMao = control.QuemGanhouAMao(pesoJogador, pesoComputador);
						if (ganhouAMao == 0)
						{
							countMao++;
							maoJogador++;
						}
						else if (ganhouAMao == 1)
						{
							countMao++;
							maoComputador++;
						}
						else
						{
							countMao++;
						}

						if (maoJogador == 2)
						{
							Console.WriteLine("=======================================");
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Você venceu a rodada!");
							Console.ForegroundColor = aux;
							jogadorGanhou = true;
							acabouOJogo = control.AcabouOJogo(jogadorGanhou);//confere se acabou o jogo
							maoJogador = 0;
							maoComputador = 0;
							countMao = 0;
							acabouARodada = true;
						}
						else if (maoComputador == 2)
						{
							Console.WriteLine("=======================================");
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("O computador venceu a rodada.");
							Console.ForegroundColor = aux;
							jogadorGanhou = false;
							acabouOJogo = control.AcabouOJogo(jogadorGanhou);
							maoJogador = 0;
							maoComputador = 0;
							countMao = 0;
							acabouARodada = true;

						}
						else if (countMao > 2)
						{
							Console.WriteLine("=======================================");
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("Empate...");
							Console.ForegroundColor = aux;
							maoJogador = 0;
							maoComputador = 0;
							countMao = 0;
							acabouARodada = true;
							Console.WriteLine("->Pontos jogador: " + pontos.getpontosJogador());
							Console.WriteLine("->Pontos computador: " + pontos.getpontosComputador());
							acabouOJogo = pontos.AcabouOJogo();
						}
						else
						{
							continue;
						}


					}

				}
				catch (Excecoes e)
				{
					Console.WriteLine(e.Message);
				}

		}
		}

	}
}