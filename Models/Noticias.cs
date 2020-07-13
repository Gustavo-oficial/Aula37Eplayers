using System;
using System.Collections.Generic;
using System.IO;

namespace Aula37E_players.Models
{
    public class Noticias : EplayersBase, INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias(){
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticias a)
        {
            string[] linha = { PreparararLinha(a) };
            File.AppendAllLines(PATH, linha);
        }

         private string PreparararLinha(Noticias a){
            return $"{a.IdNoticia}; {a.Titulo}; {a.Texto}";
        }

        public List<Noticias> ReadAll()
        {
            List<Noticias> noticias = new List<Noticias>();
            string [] linhas = File.ReadAllLines(PATH);
             foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia1 = new Noticias();
                noticia1.IdNoticia = Int32.Parse(linha[0]);
                noticia1.Titulo = linha[1];
                noticia1.Texto = linha[2];
                noticia1.Imagem = linha[3];

                noticias.Add(noticia1);
            }
            return noticias;
        }

        public void Update(Noticias a)
        {
            
        }

        public void Delete(int id)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(PATH, linhas);
        }

    }
}