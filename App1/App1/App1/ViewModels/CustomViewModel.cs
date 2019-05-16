using System;
using System.Collections.ObjectModel;
using System.Globalization;
using App1.Models;

namespace App1.ViewModels
{
    public class CustomViewModel :BaseViewModel
    {

        private ObservableCollection<Noticia> _noticias;

        public ObservableCollection<Noticia> Noticias
        {
            get { return _noticias; }
            set { SetProperty(ref _noticias, value); }
        }

        public CustomViewModel()
        {
            _noticias = new ObservableCollection<Noticia>(new[]
            {
                new Noticia{Chamada="Confira 5 filmes não clichês sobre maternidade",Banner="https://www.uninassau.edu.br/sites/mauriciodenassau.edu.br/files/styles/home_noticia_80x80/public/fields/imagemCapa/noticias/2019/05/tudosobreminhamae-600x400.jpg",HorarioChamada = HourToLiteral(DateTime.UtcNow.AddDays(-5)),TipoNoticia="Educação" },
                new Noticia{Chamada="Enfermagem: conheça o olhar de quem a escolheu como profissão",Banner="https://www.uninassau.edu.br/sites/mauriciodenassau.edu.br/files/styles/home_noticia_80x80/public/fields/imagemCapa/noticias/2019/05/ofisinas_2019.1_3.jpg",HorarioChamada = HourToLiteral(DateTime.UtcNow.AddDays(-15)),TipoNoticia="Educação" },
                new Noticia{Chamada="Mães de crianças com doenças raras: o direito de estudar",Banner="https://www.uninassau.edu.br/sites/mauriciodenassau.edu.br/files/styles/home_noticia_80x80/public/fields/imagemCapa/noticias/2019/05/ead_1.jpg",HorarioChamada = HourToLiteral(DateTime.UtcNow.AddDays(5)),TipoNoticia="Educação" },
                new Noticia{Chamada="Dia da Abolição da Escravatura: confira uma lista de filmes que abordam a temática da escravidão",Banner="https://www.uninassau.edu.br/sites/mauriciodenassau.edu.br/files/styles/home_noticia_300x130/public/fields/imagemTopo/noticias/2019/05/940x0_1542227889.jpg",HorarioChamada = HourToLiteral(DateTime.UtcNow.AddDays(-25)),TipoNoticia="Educação" },
                new Noticia{Chamada="“Chef” ou “cozinheiro”? Existem diferenças entre os termos?",Banner="https://www.uninassau.edu.br/sites/mauriciodenassau.edu.br/files/styles/home_noticia_300x130/public/fields/imagemTopo/noticias/2019/05/restaurant-939437_960_720.jpg",HorarioChamada = HourToLiteral(DateTime.UtcNow),TipoNoticia="Educação" }
            });
        }

        public string HourToLiteral(DateTime datahora)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = datahora.Day;
            int ano = datahora.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(datahora.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(datahora.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;
            return data;
        }
        
    }
}
