using System;
using System.Collections.Generic;
using System.IO;

namespace Aula37E_players.Models
{
    public class Equipe : EplayersBase, IEquipe
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";

         public Equipe(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Equipe e)
        {
            string[] linha = { PreparararLinha(e) };
            File.AppendAllLines(PATH, linha);
        }

         private string PreparararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Delete(int id)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(PATH, linhas);
        }

        /// <summary>
        /// Le as linhas do csv
        /// </summary>
        /// <returns>Lista de Equipes</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string [] linhas = File.ReadAllLines(PATH);
             foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PreparararLinha(e) );
            ReescreverCSV(PATH, linhas);
        }

    }
}